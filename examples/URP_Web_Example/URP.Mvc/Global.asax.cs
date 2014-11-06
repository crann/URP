using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Routing;
using URP.DataAccess;
using URP.Mvc.App_Start;

namespace URP.Mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new DatabaseSeed());

            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

        }
    }
}
