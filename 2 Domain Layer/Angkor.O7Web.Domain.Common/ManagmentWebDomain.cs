// Create by Felix A. Bueno

using Angkor.O7Framework.Common.Model;
using Angkor.O7Framework.Utility;
using Angkor.O7Framework.Web.Security;
using Angkor.O7Web.Data.Common;

namespace Angkor.O7Web.Domain.Common
{
    public class ManagmentWebDomain
    {
        private readonly CommonDataService _dataService;
        private readonly O7Principal _principal;

        public ManagmentWebDomain(string login, string password)
        {
            _dataService = new CommonDataService(login, password);
        }

        public ManagmentWebDomain(O7Principal principal) 
            : this(principal.Identity.Name, principal.Password)
        {
            _principal = principal;
        }

        public O7Response GetSupervisor(string companyId, string branchId)
        {
            var supervisor = _dataService.GetSupervisor(companyId, branchId);
            return O7SuccessResponse.MakeResponse(supervisor);
        }

        public O7Response GetCentroCostos()
        {
            var centroCosto = _dataService.GetCentroCostos(_principal.Company, _principal.Branch);
            var centroCostoSerialize = O7JsonSerealizer.Serialize(centroCosto);
            return O7SuccessResponse.MakeResponse(centroCostoSerialize);
        }
    }
}