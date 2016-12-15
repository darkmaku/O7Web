// Create by Felix A. Bueno

using System.Collections.Generic;
using Angkor.O7Framework.Data;
using Angkor.O7Framework.Data.Common;
using Angkor.O7Web.Common.Security.Entity;
using Angkor.O7Web.Data.Security.DataMapper;

namespace Angkor.O7Web.Data.Security
{
    public class SecurityDataService : O7DataAccessService
    {
        public SecurityDataService(string login, string password) : base(login, password)
        {
        }

        public List<Company> ListCompanies()
        {
            using (var dataAccess = new O7DataAccess(DataConnection))
                return dataAccess.ExecuteFunction<Company>("SECURITY.COMPANIES_LIST", typeof(CompanyDataMapper));
        }

        public List<Branch> ListBranches(string companyId)
        {
            using (var dataAccess = new O7DataAccess(DataConnection))
            {
                var parameter = new O7Parameter();
                parameter.Add("COMPANY", companyId);
                return dataAccess.ExecuteFunction<Branch>("SECURITY.BRANCHES_LIST", parameter, typeof(BranchDataMapper));
            }
        }

        public IEnumerable<Module> ListModules(string companyId, string branchId)
        {
            using (var dataAccess = new O7DataAccess(DataConnection))
            {
                var parameter = new O7Parameter();
                parameter.Add("COMPANY", companyId);
                parameter.Add("BRANCH", branchId);
                return dataAccess.ExecuteFunction<Module>("SECURITY.MODULES_INSTALLED", parameter, typeof(ModuleDataMapper));
            }
        }
    }
}