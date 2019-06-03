using Dominio.Interfaces;
using Repositorio;
using Repositorio.DatabaseContext;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Configuration;
using System.Web.Http;

namespace WebApi.App_Start
{
    public class IocStartup
    {
        public static Container Container { get; private set; }

        [System.Obsolete]
        public static void Initialize()
        {
            if (Container == null)
                Container = new Container();

            Container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            Container.RegisterSingleton(new ApplicationDbContext(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString));
            Container.Register<ITransmissoraRepository, TransmissoraRepository>(Lifestyle.Scoped);
            Container.Register<IFaturaRepository, FaturaRepository>(Lifestyle.Scoped);
        }

        public static void SetDependencyResolver()
        {
            Container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            Container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(Container);
        }
    }
}