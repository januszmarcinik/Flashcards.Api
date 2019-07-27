using Autofac;
using Autofac.Extensions.DependencyInjection;
using Flashcards.Api.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using NLog;
using NLog.Extensions.Logging;
using NLog.Web;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Text;
using Flashcards.Infrastructure.ContainerModules;
using Flashcards.Infrastructure.DataAccess;
using Flashcards.Infrastructure.Extensions;
using Flashcards.Infrastructure.Settings;

namespace Flashcards.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IHostingEnvironment HostingEnvironment { get; }
        public IContainer Container { get; private set; }

        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            HostingEnvironment = hostingEnvironment;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(); 
            services.AddMemoryCache();

            services.AddDbContext<EFContext>(options =>
            {
                options.UseSqlServer(Configuration.GetSettings<DatabaseSettings>().ConnectionString);
                options.UseLazyLoadingProxies();
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    var jwtSettings = Configuration.GetSettings<JwtSettings>();

                    options.RequireHttpsMetadata = false;
                    options.Configuration = new OpenIdConnectConfiguration();
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = jwtSettings.Issuer,
                        ValidateAudience = false,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),
                        ValidateLifetime = true
                    };
                });

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new Info { Title = "Flashcards API", Version = "v1" }));

            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterModule<ServicesModule>();
            builder.RegisterModule(new SettingsModule(Configuration));
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule<MediatorModule>();
            builder.RegisterInstance(LogManager.GetCurrentClassLogger()).As<NLog.ILogger>();

            Container = builder.Build();
            return new AutofacServiceProvider(Container);
        }

        public void Configure(IApplicationBuilder app, IApplicationLifetime appLifetime, IServiceProvider serviceProvider, ILoggerFactory loggerFactory)
        {
            app.UseStaticFiles();

            loggerFactory.AddNLog();
            HostingEnvironment.ConfigureNLog($"nlog.{HostingEnvironment.EnvironmentName}.config");

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Flashcards API V1"));

            app.UseCors(cors =>
            {
                cors.AllowAnyOrigin();
                cors.AllowAnyMethod();
                cors.AllowAnyHeader();
            });

            app.UseMiddleware(typeof(ExceptionHandlerMiddleware));
            app.UseAuthentication();
            app.UseMvc();

            appLifetime.ApplicationStopped.Register(() => Container.Dispose());
        }
    }
}
