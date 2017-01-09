//Create by Felix A. Bueno

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Angkor.O7Framework.Common.Model;
using Angkor.O7Framework.Domain.Response;
using Angkor.O7Framework.Utility;
using Angkor.O7Framework.Web.WebResult;
using Angkor.O7Web.Common.Security.Entity;
using Angkor.O7Web.Common.Utility;
using Angkor.O7Web.Domain.Common.ErrorResponseComponents;
using Angkor.O7Web.Domain.Common.SecurityComponents;
using Angkor.O7Web.Domain.Security;
using Angkor.O7Web.Domain.Security.Components;
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
        public ActionResult LogInPost()
        {
            var formCollection = Request.Form;

            var login = formCollection["logIn"];
            var password = formCollection["password"];
            var company = formCollection["companies"];
            var branch = formCollection["branches"];

            object[] args = { login, password };
            var domainContext = SecurityInterface.Make<SecurityWebDomain, SecurityFlow>(args);
            var userResponse = domainContext.GetUserName(company, branch);

            var successResponse = userResponse as O7SuccessResponse<string>;

            //TODO: cambiar proceso
            if (successResponse == null) return ErrorResponse.Make(500, "Error interno del servidor");
            //if (successResponse == null) return O7HttpResult.MakeRedirectError(500, "Error interno del servidor");

            var cookieValue = new CredentialCookie(login, password, company, branch, successResponse.Value1);
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
            //TODO: cambiar proceso
            if (currentSource == null) return ErrorResponse.Make(500, "");

            currentSource.Value1.Append("Url", $"/Security/Access?credential={cookie.Value.ToUriPath()}");

            var mapper = new SwitchModuleViewModelMapper();
            mapper.SetSource(currentSource);

            return O7HttpResult.MakeActionResult(modules, mapper);
        }
    }
}