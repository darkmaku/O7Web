// Create by Felix A. Bueno

using Angkor.O7Framework.Utility;
using Angkor.O7Web.Data.Security;

namespace Angkor.O7Web.Domain.Security
{
    public class SecurityJsonDomain
    {
        public static string ListCompanies(string login, string password)
        {
            var dataService = new InformationDataService(login, password);
            var companies = dataService.ListCompanies();
            return O7JsonSerealizer.Serialize(companies);
        }

        public static string ListBranches(string login, string password, string companyId)
        {
            var dataService = new InformationDataService(login, password);
            var companies = dataService.ListBranches(companyId);
            return O7JsonSerealizer.Serialize(companies);
        }

    }
}