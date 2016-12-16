// Create by Felix A. Bueno

using Angkor.O7Framework.Domain;
using Angkor.O7Framework.Domain.Response;
using Angkor.O7Web.Data.Common;

[assembly: O7DomainException]

namespace Angkor.O7Web.Domain.Common
{
    public class ManagmentWebDomain
    {
        private readonly CommonDataService _dataService;

        public ManagmentWebDomain(string login, string password)
        {
            _dataService = new CommonDataService(login, password);
        }

        public O7Response GetSupervisor(string companyId, string branchId)
        {
            var supervisor = _dataService.GetSupervisor(companyId, branchId);
            return O7SuccessResponse.MakeResponse(supervisor);
        }
    }
}