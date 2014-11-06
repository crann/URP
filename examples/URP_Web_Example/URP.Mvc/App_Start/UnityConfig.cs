using System.Web.Mvc;
using Microsoft.Practices.Unity;
using URP.DataAccess.Scaffolding;
using URP.DataAccess.Scaffolding.Implementation;
using Unity.Mvc5;

namespace URP.Mvc.App_Start
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // Scaffolding Mappings 
            container.RegisterType<IDatabaseFactory, DatabaseFactory>(new HierarchicalLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());

            // Repository Mappings
            container.RegisterType(typeof(IRepository<>), typeof(GenericRepository<>), (new HierarchicalLifetimeManager()));

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}