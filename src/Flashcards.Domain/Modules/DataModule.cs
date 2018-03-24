using Autofac;
using Flashcards.Domain.Data.Abstract;
using Flashcards.Domain.Data.Concrete;

namespace Flashcards.Domain.Modules
{
    public class DataModule : Module
    {
        private readonly string _databaseName;

        public DataModule(string databaseName)
        {
            _databaseName = databaseName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EFContext>()
                .As<IDbContext>()
                .WithParameter("databaseName", _databaseName)
                .InstancePerLifetimeScope();
        }
    }
}
