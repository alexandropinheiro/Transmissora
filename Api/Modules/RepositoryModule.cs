using Autofac;
using Dominio.Interfaces;
using Repositorio;
using Repositorio.DatabaseContext;

namespace Api.Modules
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().InstancePerLifetimeScope();

            builder.RegisterType<TransmissoraRepository>().As<ITransmissoraRepository>();
            builder.RegisterType<FaturaRepository>().As<IFaturaRepository>();
        }
    }
}