// Create by Felix A. Bueno
using System.Collections.Generic;
using Angkor.O7Framework.Common.Model;
using Angkor.O7Framework.Data.Tool;
using Angkor.O7Framework.Infrastructure;
using Angkor.O7Web.Common.Security.Entity;
using Angkor.O7Web.Data.Security.DataMapper;

namespace Angkor.O7Web.Data.Security
{
    public class SecurityDataService : O7AbstractData
    {
        public SecurityDataService(string login, string password) : base(login, password)
        {
        }

        public List<Company> ListCompanies()
            => DataAccess.ExecuteFunction<Company>("SECURITY.companies_list", typeof(CompanyDataMapper));

        public List<Branch> ListBranches(string companyId)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_company", companyId));
            return DataAccess.ExecuteFunction<Branch>("SECURITY.branches_list", parameters, typeof(BranchDataMapper));
        }

        public List<Module> ListModules(string companyId, string branchId)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_company", companyId));
            parameters.Add(O7Parameter.Make("p_branch", branchId));
            return DataAccess.ExecuteFunction<Module>("SECURITY.modules_installed", parameters, typeof(ModuleDataMapper));
        }

        public string GetUserName(string companyId, string branchId)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_company", companyId));
            parameters.Add(O7Parameter.Make("p_branch", branchId));
            return DataAccess.ExecuteFunction<string>("SECURITY.get_user_name", parameters);
        }
    }
}