// Create by Felix A. Bueno

using System.Web.Mvc;
using Angkor.O7Framework.Utility;
using Angkor.O7Framework.Web.Base;
using Angkor.O7Framework.Web.HtmlHelper;
using Angkor.O7Framework.Web.Security;
using Angkor.O7Web.Common.Utility;
using Angkor.O7Web.Interface.Security.Controllers.Transfer;

namespace Angkor.O7Web.Interface.Advisory.Controller
{
    public class SecurityController : O7Controller
    {
        public ActionResult Access(string credential)
        {
            if (string.IsNullOrEmpty(credential)) return null;

            var cryptography = new O7Cryptography(Constant.CRYPTO_KEY);
            var dencryptedValue = cryptography.Decrypt(credential);
            var serializedValue = O7JsonSerealizer.Deserialize<CredentialCookie>(dencryptedValue);

            var cookie = O7Authentication.Generate(serializedValue.CompanyId, serializedValue.BranchId, serializedValue.Login,
                serializedValue.Name, serializedValue.Password);

            Response.Cookies.Add(cookie);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            O7Authentication.SignOut();
            return Redirect(LinkHelper.SourceLink("Security", "Signout"));
        }
    }
}