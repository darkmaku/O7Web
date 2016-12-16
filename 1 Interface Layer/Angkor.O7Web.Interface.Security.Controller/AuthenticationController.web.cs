//Create by Felix A. Bueno

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Angkor.O7Framework.Domain.Response;
using Angkor.O7Framework.Utility;
using Angkor.O7Framework.Web.WebResult;
using Angkor.O7Web.Common.Security.Entity;
using Angkor.O7Web.Common.Utility;
using Angkor.O7Web.Domain.Security;
using Angkor.O7Web.Interface.Security.Controllers.Transfer;
using Angkor.O7Web.Interface.Security.Controllers.ViewModelMapper;
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

            var domainContext = new SecurityWebDomain(model.Login, model.Password);
            var userResponse = domainContext.GetUserName(model.CompanyId, model.BranchId);

            var successResponse = userResponse as O7SuccessResponse<string>;

            if (successResponse == null) return O7HttpResult.MakeRedirectError(500, "Error interno del servidor");

            var cookieValue = new CredentialCookie (model.Login, model.Password, model.CompanyId, model.BranchId, successResponse.Value1);
            var serializedValue = O7JsonSerealizer.Serialize(cookieValue);

            var cryptography = new O7Cryptography(Constant.CRYPTO_KEY);
            var encryptedValue = cryptography.Encrypt(serializedValue);

            var cookie = Response.Cookies[Constant.TEMP_COOKIE] ?? new HttpCookie(Constant.TEMP_COOKIE);
            cookie.Value = encryptedValue;
            cookie.Expires = DateTime.Now.AddMinutes(2);

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

            var domainContext = new SecurityWebDomain(serializedValue.Login, serializedValue.Password);
            var modules = domainContext.ListModules(serializedValue.CompanyId, serializedValue.BranchId);

            var currentSource = modules as O7SuccessResponse<List<Module>>;

            if (currentSource == null) return O7HttpResult.MakeRedirectError(500, "");

            currentSource.Value1.Append("Url", $"?credential={cookie.Value.ToUriPath()}");

            var mapper = new SwitchModuleViewModelMapper();
            mapper.SetSource(currentSource);

            return O7HttpResult.MakeActionResult(modules, mapper);
        }
    }
}