// Create by Felix A. Bueno

using System.Web;
using System.Web.Routing;
using System.Web.Security;
using Angkor.O7Framework.Web;
using Angkor.O7Web.Interface.Builder.SecurityFeatures;

namespace Angkor.O7Web.Interface.Builder
{
    public static class FeatureBuilder
    {
        public static void InitializeSecurityFeatures()
        {
            SecurityRoutes.RegisterRoutes(RouteTable.Routes);
        }

        public static void InitializeSecurityCredentials(HttpRequest request, HttpContext context)
        {
            var cookie = request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie == null) return;
            context.Current.User = O7Authentication.Extract(cookie);
        }
    }
}