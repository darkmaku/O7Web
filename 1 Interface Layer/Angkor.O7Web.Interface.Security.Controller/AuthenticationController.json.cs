 // Create by Felix A. Bueno

using System.Web.Mvc;
using Angkor.O7Web.Domain.Security;

namespace Angkor.O7Web.Interface.Security.Controllers
{
    public partial class AuthenticationController
    {
        [HttpPost]
        public JsonResult GetCompanies(string login, string password)
        {
            var result = SecurityJsonDomain.ListCompanies(login, password);
            return Json(result, JsonRequestBehavior.AllowGet);            
        }

        [HttpPost]
        public JsonResult GetBranches(string login, string password, string companyId)
        {
            var result = SecurityJsonDomain.ListBranches(login, password, companyId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}