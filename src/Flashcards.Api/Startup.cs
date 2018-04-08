using Autofac;
using Autofac.Extensions.DependencyInjection;
using Flashcards.Api.Middleware;
using Flashcards.Core.Modules;
using Flashcards.Core.Settings;
using Flashcards.Domain.Modules;
using Flashcards.Infrastructure.Managers.Abstract;
using Flashcards.Infrastructure.Modules;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    var jwtSettings = new JwtSettings();
                    Configuration.GetSection("Jwt").Bind(jwtSettings);

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

            builder.RegisterModule(new DataModule(HostingEnvironment.EnvironmentName));
            builder.RegisterModule<MapperModule>();
            builder.RegisterModule<ManagerModule>();
            builder.RegisterModule(new SettingsModule(Configuration));
            builder.RegisterModule<ServiceModule>();
            builder.RegisterModule<CommandModule>();
            builder.RegisterInstance(LogManager.GetCurrentClassLogger()).As<NLog.ILogger>();

            Container = builder.Build();
            return new AutofacServiceProvider(Container);
        }

        public void Configure(IApplicationBuilder app, IApplicationLifetime appLifetime, IServiceProvider serviceProvider, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddNLog();
            HostingEnvironment.ConfigureNLog("nlog.config");

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Flashcards API V1"));

            app.UseCors(cors =>
            {
                cors.WithOrigins("http://localhost:4200");
                cors.AllowAnyMethod();
                cors.AllowAnyHeader();
            });

            if (HostingEnvironment.IsDevelopment())
            {
                serviceProvider.GetService<ITestDataSeedingManager>().Seed();
            }

            app.UseMiddleware(typeof(ExceptionHandlerMiddleware));
            app.UseAuthentication();
            app.UseMvc();

            appLifetime.ApplicationStopped.Register(() => Container.Dispose());
        }
    }
}
