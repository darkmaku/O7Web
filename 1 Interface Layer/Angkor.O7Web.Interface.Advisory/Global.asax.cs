using System.Web.Mvc;
using System.Web.Routing;
using Angkor.O7Web.Interface.AppStart;

namespace Angkor.O7Web.Interface.Advisory
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            AdvisoryAppStart.BuildRouteConfig(RouteTable.Routes);
        }
    }
}
