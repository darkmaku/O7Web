// Create by Felix A. Bueno

using System.Web.Mvc;

namespace Angkor.O7Web.Interface.Security.Controllers
{
    public partial class AuthenticationController
    {
        [HttpPost]
        public JsonResult GetCompanies(string login, string password)
        {
            var result = _jsonService.ListCompanies(login, password);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetBranches(string companyId)
        {
            var result = _jsonService.ListBranches(companyId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}