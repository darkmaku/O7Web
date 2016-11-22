// Create by Felix A. Bueno

using Angkor.O7Web.Data.Security;
using Angkor.O7Web.Domain.Contract;
using Angkor.O7Web.Interface.Security.Model;

namespace Angkor.O7Web.Domain.Security
{
    public class SecurityWebDomain : BaseDomain
    {           
        public SecurityWebDomain(string login, string password) : base(login, password)
        {
        }

        public ListModulesContract ListModules(string companyId, string branchId)
        {
            var dataService = new InformationDataService(Login, Password);            
            var contract = new ListModulesContract();
            contract.Modules = dataService.ListModules(companyId, branchId);
            return contract;
        }
    }
}