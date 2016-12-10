using System.Web.Mvc;
using System.Web.Routing;
using Angkor.O7Web.Interface.SharedSource.Controllers;

namespace Angkor.O7Web.Interface.SharedSource
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RouteTable.Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            RouteTable.Routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Error", action = "Error401", id = UrlParameter.Optional },
                namespaces: new[] { typeof(ErrorController).Namespace }
            );
        }
    }
}
