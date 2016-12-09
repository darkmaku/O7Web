﻿//Create by Felix A. Bueno

using System;
using System.Web;
using System.Web.Mvc;
using Angkor.O7Framework.Utility;
using Angkor.O7Web.Common.Utility;
using Angkor.O7Web.Domain.Security;
using Angkor.O7Web.Interface.Security.Controllers.Transfer;
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
            if (!model.ValidViewModel) return View(model);

            var cookieValue = new CredentialCookie (model.Login, model.Password, model.CompanyId, model.BranchId);
            var serializedValue = O7JsonSerealizer.Serialize(cookieValue);

            var cryptography = new O7Cryptography(Constant.CRYPTO_KEY);
            var encryptedValue = cryptography.Encrypt(serializedValue);

            var cookie = Response.Cookies[Constant.TEMP_COOKIE] ?? new HttpCookie(Constant.TEMP_COOKIE);
            cookie.Value = encryptedValue;
            cookie.Expires = DateTime.Now.AddDays(1);

            Response.Cookies.Add(cookie);
            return RedirectToAction("SwitchModule");
        }

        public ActionResult SwitchModule()
        {
            var cookie = Request.Cookies[Constant.TEMP_COOKIE];
            if (cookie == null) return RedirectToAction("LogIn");

            var cryptography = new O7Cryptography(Constant.CRYPTO_KEY);
            var dencryptedValue = cryptography.Decrypt(cookie.Value);
            var serializedValue = O7JsonSerealizer.Deserialize<CredentialCookie>(dencryptedValue);

            var model = new SwitchModuleViewModel();
            using (var domain = new SecurityWebDomain(serializedValue.Login, serializedValue.Password))
            {
                var response = domain.ListModules(serializedValue.CompanyId, serializedValue.BranchId);
                if (response.HasError)
                {
                    model.ErrorMessage = response.ErrorMessage;
                    model.ErrorCode = response.ErrorCode;
                }
                else
                {
                    model.Modules = response.Response.Item1.Append("Url",$"?credential={cookie.Value.ToUriPath()}");
                }
            }
            return View(model);
        }
    }
}