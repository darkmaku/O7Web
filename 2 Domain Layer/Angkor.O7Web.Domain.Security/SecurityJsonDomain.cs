// Create by Felix A. Bueno

using Angkor.O7Framework.Utility;
using Angkor.O7Web.Data.Security;

namespace Angkor.O7Web.Domain.Security
{
    public class SecurityJsonDomain : BaseDomain
    {
        public SecurityJsonDomain(string login, string password) : base(login, password)
        {
        }

        public string ListCompanies()
        {
            var dataService = new InformationDataService(Login, Password);
            var companies = dataService.ListCompanies();
            return O7JsonSerealizer.Serialize(companies);
        }

        public string ListBranches(string companyId)
        {
            var dataService = new InformationDataService(Login, Password);
            var companies = dataService.ListBranches(companyId);
            return O7JsonSerealizer.Serialize(companies);
        }

    }
}