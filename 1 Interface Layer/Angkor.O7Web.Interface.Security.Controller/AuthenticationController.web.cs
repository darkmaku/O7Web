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
                var cryptography = new O7Cryptography(Constant.CRYPTO_KEY);
                var paramBuilder = new O7ParamBuilder();
                paramBuilder.AppendParameter("login", model.Login);
                paramBuilder.AppendParameter("password", model.Password);
                paramBuilder.AppendParameter("company", model.CompanyId);
                paramBuilder.AppendParameter("branch", model.BranchId);
                var value = cryptography.Encrypt(paramBuilder.ToString());
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
            var cookie = Request.Cookies[Constant.TEMP_COOKIE];
            var cryptography = new O7Cryptography(Constant.CRYPTO_KEY);
            var cookieValue = cryptography.Decrypt(cookie.Value);
            var paramBuilder = new O7ParamBuilder(cookieValue);
            var model = new SwitchModuleViewModel();
            using (var domain = new SecurityWebDomain(paramBuilder.GetParameterValue("login"), paramBuilder.GetParameterValue("password")))
            {
                model.Modules = domain.ListModules(paramBuilder.GetParameterValue("company"), paramBuilder.GetParameterValue("branch")).Modules;
            }
            return View(model);
        }
    }
}