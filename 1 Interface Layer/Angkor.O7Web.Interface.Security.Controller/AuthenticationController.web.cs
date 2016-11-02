// Create by Felix A. Bueno

using System.Web.Mvc;
using Angkor.O7Framework.Web;
using Angkor.O7Web.Interface.Security.Model;

namespace Angkor.O7Web.Interface.Security.Controllers
{
    public partial class AuthenticationController
    {
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(LogInViewModel model)
        {
            var contract = _domainService.ValidateUser(model);
            if (!contract.Success) return View(contract.ViewModel);
            return RedirectToAction("SwitchModule");
        }

        public ActionResult SwitchModule()
        {
            return null;
        }
    }
}