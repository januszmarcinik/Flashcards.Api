using Autofac;
using Flashcards.Core;
using Flashcards.Domain.Cards;
using Flashcards.Infrastructure.Extensions;
using Flashcards.Infrastructure.Services;
using Flashcards.Infrastructure.Settings;
using Microsoft.Extensions.Configuration;

namespace Flashcards.Infrastructure.ContainerModules
{
    public class MediatorModule : Module
    {
        private readonly IConfiguration _configuration;

        public MediatorModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        protected override void Load(ContainerBuilder builder)
        {
            var settings = _configuration.GetSettings<AppSettings>();
            if (settings.IsCloud)
            {
                builder.RegisterType<AzureServiceBus>().As<IEventBus>().SingleInstance();
            }
            else
            {
                builder.RegisterType<RabbitMqEventBus>().As<IEventBus>().SingleInstance();
            }

            builder.RegisterType<Mediator>().As<IMediator>().InstancePerLifetimeScope();

            builder
                .Register(factory =>
                {
                    var lifetimeScope = factory.Resolve<ILifetimeScope>();
                    return new AutofacDependencyResolver(lifetimeScope.BeginLifetimeScope());
                })
                .As<IDependencyResolver>()
                .InstancePerLifetimeScope();

            var handlersAssembly = typeof(Card).Assembly;

            builder
                .RegisterAssemblyTypes(handlersAssembly)
                .AsClosedTypesOf(typeof(ICommandHandler<>))
                .InstancePerLifetimeScope();

            builder
                .RegisterAssemblyTypes(handlersAssembly)
                .AsClosedTypesOf(typeof(IQueryHandler<,>))
                .InstancePerLifetimeScope();

            builder
                .RegisterAssemblyTypes(handlersAssembly)
                .AsClosedTypesOf(typeof(IEventHandler<>))
                .InstancePerLifetimeScope();
        }
    }
}
