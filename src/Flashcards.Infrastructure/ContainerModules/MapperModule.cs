using Autofac;
using AutoMapper;
using Flashcards.Infrastructure.Mappers;

namespace Flashcards.Infrastructure.ContainerModules
{
    public class MapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(AutoMapperConfig.Initialize()).As<IMapper>().SingleInstance();
        }
    }
}
