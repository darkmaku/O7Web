// Create by Felix A. Bueno

using System.Web.Mvc;
using Angkor.O7Framework.Web.Base;

namespace Angkor.O7Web.Interface.Finantial.Controller
{
    public class SecurityController : O7Controller
    {
        public ActionResult Access(string credential)
        {
            return View();
        }
        
    }
}