// Create by Felix A. Bueno

using Angkor.O7Web.Data.Security;
using Angkor.O7Web.Interface.Security.Model;

namespace Angkor.O7Web.Domain.Security
{
    public class SecurityWebDomain
    {
        public static SwitchModuleViewModel ListModules(string login, string password, string companyId, string branchId)
        {
            var dataService = new InformationDataService(login, password);
            var result = new SwitchModuleViewModel();
            result.Modules = dataService.ListModules(companyId, branchId);
            return result;
        }
    }
}