// Create by Felix A. Bueno

using Angkor.O7Framework.Domain;
using Angkor.O7Framework.Domain.Response;
using Angkor.O7Framework.Utility;
using Angkor.O7Web.Data.Security;

[assembly: O7DomainException]

namespace Angkor.O7Web.Domain.Security
{
    public class SecurityJsonDomain
    {
        private readonly SecurityDataService _dataService;

        public SecurityJsonDomain(string login, string password)
        {
            _dataService = new SecurityDataService(login, password);
        }

        public O7Response ListCompanies()
        {
            var companies = _dataService.ListCompanies();
            var companiesSerialized = O7JsonSerealizer.Serialize(companies);
            return O7SuccessResponse.MakeResponse(companiesSerialized);
        }

        public O7Response ListBranches(string companyId)
        {
            var companies = _dataService.ListBranches(companyId);
            var companiesSerialized = O7JsonSerealizer.Serialize(companies);
            return O7SuccessResponse.MakeResponse(companiesSerialized);
        }
    }
}