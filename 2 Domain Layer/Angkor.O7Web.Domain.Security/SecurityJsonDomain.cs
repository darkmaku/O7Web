// Create by Felix A. Bueno

using System.Collections.Generic;
using Angkor.O7Framework.Common.Model;
using Angkor.O7Framework.Utility;
using Angkor.O7Framework.Web.Model;
using Angkor.O7Web.Data.Security;
using Angkor.O7Web.Domain.Security.Model;

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

        public O7Response ListMenus(string companyId, string branchId, string menuId)
        {
            var menus = _dataService.ListMenus(companyId, branchId, menuId);
            var o7Menus = Pattern.SortMenus(menus, menuId);
            return O7SuccessResponse.MakeResponse(o7Menus);
        }
    }
}