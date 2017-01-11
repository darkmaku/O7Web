// Create by Felix A. Bueno
using System.Web.Mvc;
using Angkor.O7Framework.Domain;
using Angkor.O7Framework.Web.WebResult;
using Angkor.O7Web.Domain.Common;
using Angkor.O7Web.Domain.Security;

namespace Angkor.O7Web.Interface.Security.Controllers
{
    public partial class AuthenticationController
    {
        [HttpPost]
        public JsonResult GetCompanies(string login, string password)
        {
            var argDomain = new object[] {login, password};
            var argFlow = new object[] {login};
            var domain = O7DomainInstanceMaker.MakeInstance<SecurityJsonDomain, BasicFlow>(argDomain, argFlow);
            return O7HttpResult.MakeJsonResult(domain.ListCompanies());
        }

        [HttpPost]
        public JsonResult GetBranches(string login, string password, string companyId)
        {
            var argDomain = new object[] {login, password};
            var argFlow = new object[] {login};
            var domain = O7DomainInstanceMaker.MakeInstance<SecurityJsonDomain, BasicFlow>(argDomain, argFlow);
            return O7HttpResult.MakeJsonResult(domain.ListBranches(companyId));
        }
    }
}