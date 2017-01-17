using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Angkor.O7Framework.Web.Security;
using Angkor.O7Web.Interface.AppStart;
using Angkor.O7Web.Interface.AppStart.AppStart;

namespace Angkor.O7Web.Interface.Advisory
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            AdvisoryAppStart.BuildRouteConfig(RouteTable.Routes);
        }

        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            
            //var authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            //if (authCookie != null) HttpContext.Current.User = O7Authentication.ExtractUser(authCookie);            
        }
    }
}
