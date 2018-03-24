using Autofac;
using Autofac.Extensions.DependencyInjection;
using Flashcards.Api.Middleware;
using Flashcards.Domain.Modules;
using Flashcards.Infrastructure.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NLog;
using NLog.Extensions.Logging;
using NLog.Web;
using Swashbuckle.AspNetCore.Swagger;
using System;

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
            services.AddMvc()
                .AddJsonOptions(x => x.SerializerSettings.Formatting = Formatting.Indented);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Flashcards API", Version = "v1" });
            });

            var builder = new ContainerBuilder();
            builder.Populate(services);

            builder.RegisterModule(new DataModule(HostingEnvironment.EnvironmentName));
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule<MapperModule>();
            builder.RegisterModule<ManagerModule>();
            builder.RegisterModule(new SettingsModule(Configuration));
            builder.RegisterModule<ServiceModule>();
            builder.RegisterModule<CommandModule>();
            builder.RegisterInstance(LogManager.GetCurrentClassLogger()).As<NLog.ILogger>();

            Container = builder.Build();
            return new AutofacServiceProvider(Container);
        }

        public void Configure(IApplicationBuilder app, IApplicationLifetime appLifetime, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddNLog();
            app.AddNLogWeb();
            HostingEnvironment.ConfigureNLog("nlog.config");

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Flashcards API V1");
            });

            if (HostingEnvironment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware(typeof(ExceptionHandlerMiddleware));
            app.UseAuthentication();
            app.UseMvc();

            appLifetime.ApplicationStopped.Register(() => Container.Dispose());
        }
    }
}
