//Create by Felix A. Bueno
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Angkor.O7Framework.Common.Model;
using Angkor.O7Framework.Domain;
using Angkor.O7Framework.Utility;
using Angkor.O7Framework.Web.HtmlHelper;
using Angkor.O7Web.Common.Security.Entity;
using Angkor.O7Web.Common.Utility;
using Angkor.O7Web.Domain.Common;
using Angkor.O7Web.Domain.Security;
using Angkor.O7Web.Interface.Security.Controllers.Transfer;

namespace Angkor.O7Web.Interface.Security.Controllers
{
    public partial class AuthenticationController
    {
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [ActionName("LogIn")]
        public ActionResult LogInPost()
        {
            var model = get_values_login_post(Request.Form);

            var argDomain = new object[] { model.Item1, model.Item2 };
            var argFlow = new object[] { model.Item1 };
            var domain = O7DomainInstanceMaker.MakeInstance<SecurityWebDomain, BasicFlow>(argDomain, argFlow);
            var userResponse = domain.GetUserName(model.Item3, model.Item4);

            var successResponse = userResponse as O7SuccessResponse<string>;            
            if (successResponse == null) return Redirect(LinkHelper.SourceLink("Error", "ServerError"));

            var cookieValue = new CredentialCookie(model.Item1, model.Item2, model.Item3, model.Item4, successResponse.Value1);
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

            var argDomain = new object[] { serializedValue.Login, serializedValue.Password };
            var argFlow = new object[] { serializedValue.Login };
            var domain = O7DomainInstanceMaker.MakeInstance<SecurityWebDomain, BasicFlow>(argDomain, argFlow);            
            var modules = domain.ListModules(serializedValue.CompanyId, serializedValue.BranchId);

            var currentSource = modules as O7SuccessResponse<List<Module>>;
            if (currentSource == null) return Redirect(LinkHelper.SourceLink("Error", "ServerError", Tuple.Create("credential", cookie.Value)));
            currentSource.Value1.Append("Url", cookie.Value.ToUriPath());

            ViewData["modules"] = currentSource.Value1;
            return View();
        }
    }
}