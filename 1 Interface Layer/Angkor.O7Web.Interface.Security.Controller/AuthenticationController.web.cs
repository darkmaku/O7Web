//Create by Felix A. Bueno

using System;
using System.Web;
using System.Web.Mvc;
using Angkor.O7Framework.Utility;
using Angkor.O7Web.Common.Utility;
using Angkor.O7Web.Domain.Security;
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
            if (model.ValidViewModel)
            {
                var cryptography = new Cryptography(Constant.CRYPTO_KEY);
                var value = cryptography.Encrypt($"login={model.Login}&password={model.Password}&company={model.CompanyId}&branch={model.BranchId}");                
                var cookie = Response.Cookies[Constant.TEMP_COOKIE] ?? new HttpCookie(Constant.TEMP_COOKIE);
                cookie.Value = value;                
                cookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(cookie);
                return RedirectToAction("SwitchModule");
            }
            return View(model);
        }

        public ActionResult SwitchModule()
        {
            var model = new SwitchModuleViewModel();
            using (var domain = new SecurityWebDomain("CN01", "CN02"))
            {
                model.Modules = domain.ListModules("001", "001").Modules;
            }
            return View(model);
        }
    }
}