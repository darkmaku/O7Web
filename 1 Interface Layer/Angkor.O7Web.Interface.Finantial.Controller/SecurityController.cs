// Create by Felix A. Bueno

using System.Web.Mvc;
using Angkor.O7Framework.Web.Base;
using Angkor.O7Framework.Web.HtmlHelper;

namespace Angkor.O7Web.Interface.Finantial.Controller
{
    public class SecurityController : O7Controller
    {
        public ActionResult Access(string credential)
        {
            if (string.IsNullOrEmpty(credential))
                return Redirect(LinkHelper.PartialLink("/Views/ErrorPage.cshtml"));

            return View();
        }
        
    }
}