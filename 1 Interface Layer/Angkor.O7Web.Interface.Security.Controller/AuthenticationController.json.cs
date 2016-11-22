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
            string companies;
            using (var domain = new SecurityJsonDomain(login, password)) companies = domain.ListCompanies();
            return Json(companies, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetBranches(string login, string password, string companyId)
        {
            string branches;
            using (var domain = new SecurityJsonDomain(login, password)) branches = domain.ListBranches(companyId);
            return Json(branches, JsonRequestBehavior.AllowGet);
        }
    }
}