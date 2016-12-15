 // Create by Felix A. Bueno

using System.Web.Mvc;
using Angkor.O7Framework.Web.WebResult;
using Angkor.O7Web.Domain.Security;

namespace Angkor.O7Web.Interface.Security.Controllers
{
    public partial class AuthenticationController
    {
        [HttpPost]
        public JsonResult GetCompanies(string login, string password)
        {
            var domain = new SecurityJsonDomain(login, password);            
            return O7HttpResult.MakeJsonResult(domain.ListCompanies());
        }

        [HttpPost]
        public JsonResult GetBranches(string login, string password, string companyId)
        {
            var domain = new SecurityJsonDomain(login, password);
            return O7HttpResult.MakeJsonResult(domain.ListBranches(companyId));
        }
    }
}