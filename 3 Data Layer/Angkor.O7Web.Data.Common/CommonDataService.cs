// Create by Felix A. Bueno

using System.Collections.Generic;
using System.Linq;
using Angkor.O7Framework.Data;
using Angkor.O7Framework.Data.Common;
using Angkor.O7Web.Common.Entity;
using Angkor.O7Web.Data.Common.DataMapper;

namespace Angkor.O7Web.Data.Common
{
    public class CommonDataService : O7DataAccessService
    {
        public CommonDataService(string login, string password) : base(login, password)
        {
        }

        public Supervisor GetSupervisor(string companyId, string branchId)
        {
            using (var dataAccess = new O7DataAccess(DataConnection))
            {
                var parameter = new O7Parameter();
                parameter.Add("COMPANY", companyId);
                parameter.Add("BRANCH", branchId);
                return dataAccess.ExecuteFunction<Supervisor>("SUPPORT.GET_SUPERVISOR", parameter, typeof(SupervisorDataMapper)).FirstOrDefault();
            }
        }

        public List<CentroCosto> GetCentroCostos(string companyId, string branchId)
        {
            using (var dataAccess = new O7DataAccess(DataConnection))
            {
                var parameter = new O7Parameter();
                parameter.Add("p_company", companyId);
                parameter.Add("p_branch", branchId);
                return dataAccess.ExecuteFunction<CentroCosto>("common_function.list_cost_center", parameter, typeof(CentroCostoDataMapper));
            }
        }
    }
}