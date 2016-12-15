// Create by Felix A. Bueno

using Angkor.O7Framework.Domain;
using Angkor.O7Framework.Domain.Response;
using Angkor.O7Web.Data.Security;

[assembly: O7DomainException]

namespace Angkor.O7Web.Domain.Security
{
    public class SecurityWebDomain
    {
        private readonly SecurityDataService _dataService;

        public SecurityWebDomain(string login, string password)
        {
            _dataService = new SecurityDataService(login, password);
        }

        public O7Response GetUserName(string companyId, string branchId)
        {
            var userName = _dataService.GetUserName(companyId, branchId);
            return O7SuccessResponse.MakeResponse(userName);
        }

        public O7Response ListModules(string companyId, string branchId)
        {
            var modules = _dataService.ListModules(companyId, branchId);
            return O7SuccessResponse.MakeResponse(modules);
        }
    }
}