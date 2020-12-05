using Autofac;
using Autofac.Extensions.DependencyInjection;
using Flashcards.Api.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Flashcards.Api.Configuration;
using Flashcards.Infrastructure.ContainerModules;
using Flashcards.Infrastructure.DataAccess;
using Flashcards.Infrastructure.Extensions;
using Flashcards.Infrastructure.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;

namespace Flashcards.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment HostingEnvironment { get; }
        public IContainer Container { get; private set; }

        public Startup(IConfiguration configuration, IWebHostEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            HostingEnvironment = hostingEnvironment;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ContractResolver =
                        new CamelCasePropertyNamesContractResolver());

            services.AddMemoryCache();
            services.AddCors();

            services.AddDbContext<EFContext>(options =>
            {
                options.UseSqlServer(Configuration.GetSettings<DatabaseSettings>().ConnectionString);
                options.UseLazyLoadingProxies();
            });

            services.AddJwtTokenAuthentication(Configuration);

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Flashcards API", Version = "v1" }));

            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterModule<ServicesModule>();
            builder.RegisterModule(new SettingsModule(Configuration));
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule<MediatorModule>();

            Container = builder.Build();
            return new AutofacServiceProvider(Container);
        }

        public void Configure(IApplicationBuilder app, IHostApplicationLifetime appLifetime)
        {
            app.UseStaticFiles();
            
            app.UseRouting();
            app.UseCors(cors =>
            {
                cors.AllowAnyOrigin();
                cors.AllowAnyMethod();
                cors.AllowAnyHeader();
            });
            
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Flashcards API V1"));

            app.UseMiddleware(typeof(ExceptionHandlerMiddleware));
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync($"Flashcards is working on '{HostingEnvironment.EnvironmentName}'...");
                });
            });

            appLifetime.ApplicationStopped.Register(() => Container.Dispose());
        }
    }
}
