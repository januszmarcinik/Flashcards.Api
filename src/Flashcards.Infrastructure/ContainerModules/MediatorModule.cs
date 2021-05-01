using Autofac;
using Flashcards.Application.Cards;
using Flashcards.Core;

namespace Flashcards.Infrastructure.ContainerModules
{
    public class MediatorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
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
