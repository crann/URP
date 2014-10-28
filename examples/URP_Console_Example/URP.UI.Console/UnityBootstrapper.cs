using Microsoft.Practices.Unity;
using URP.DataAccess.Scaffolding;
using URP.DataAccess.Scaffolding.Implementation;

namespace URP.UI.ConsoleApp
{
    public class UnityBootstrapper
    {
        public UnityBootstrapper(){ }

        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();
            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            RegisterTypes(container);

            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            // Scaffolding Mappings 
            container.RegisterType<IDatabaseFactory, DatabaseFactory>(new HierarchicalLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());

            // Repository Mappings
            container.RegisterType(typeof(IRepository<>), typeof(GenericRepository<>), (new HierarchicalLifetimeManager()));
        }
    }
}