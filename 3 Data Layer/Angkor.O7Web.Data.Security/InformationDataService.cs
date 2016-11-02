// Create by Felix A. Bueno

using System.Collections.Generic;
using Angkor.O7Framework.Data;
using Angkor.O7Framework.Data.Common;
using Angkor.O7Web.Common.Security.Entity;
using Angkor.O7Web.Data.Security.Mapper;
using Angkor.O7Web.Data.Service;

namespace Angkor.O7Web.Data.Security
{
    public class InformationDataService : DataService
    {
        public InformationDataService(string login, string password) : base(login, password)
        {
        }

        public List<Company> ListCompanies()
        {
            using (DataAccess = new O7DataAccess(DatabaseConnection))
                return DataAccess.ExecuteFunction("SECURITY.COMPANIES_LIST", new O7Parameter(), new CompanyMapper());
        }

        public List<Branch> ListBranches(string companyId)
        {
            using (DataAccess = new O7DataAccess(DatabaseConnection))
            {
                var parameter = new O7Parameter();
                parameter.Add("COMPANY", companyId);
                return DataAccess.ExecuteFunction("SECURITY.BRANCHES_LIST", parameter, new BranchMapper());
            }
        }
    }
}