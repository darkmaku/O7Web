﻿// Create by Felix A. Bueno

using System.Collections.Generic;
using Angkor.O7Framework.Data;
using Angkor.O7Framework.Data.Common;
using Angkor.O7Web.Common.Advisory.Entity;
using Angkor.O7Web.Data.Advisory.DataMapper;

namespace Angkor.O7Web.Data.Advisory
{
    public class PeriodDataService : O7DataAccessService
    {
        public PeriodDataService(string login, string password) : base(login, password)
        {
        }

        public List<Period> ListPeriods(string companyId, string branchId)
        {
            using (var dataAccess = new O7DataAccess(DataConnection))
            {
                var parameter = new O7Parameter();
                parameter.Add("COMPANY", companyId);
                parameter.Add("BRANCH", branchId);
                return dataAccess.ExecuteFunction<Period>("ADVISORY_PERIOD.LIST_PERIODS", parameter, typeof(PeriodDataMapper));
            }
        }

        public List<Year> ListAvalibleYears(string companyId, string branchId)
        {
            using (var dataAccess = new O7DataAccess(DataConnection))
            {
                var parameter = new O7Parameter();
                parameter.Add("p_company", companyId);
                parameter.Add("p_branch", branchId);
                return dataAccess.ExecuteFunction<Year>("ADVISORY_PERIOD.list_avalible_year", parameter, typeof(PeriodStateDataMapper));
            }
        }

        public bool ValidPeriod(string companyId, string branchId, string month, string year)
        {
            using (var dataAccess = new O7DataAccess(DataConnection))
            {
                var parameter = new O7Parameter();
                parameter.Add("p_company", companyId);
                parameter.Add("p_branch", branchId);
                parameter.Add("p_month", month);
                parameter.Add("p_year", year);
                return dataAccess.ExecuteFunction<int>("ADVISORY_PERIOD.valid_period_id", parameter) > 0;
            }
        }

        public bool ActivateYear(string companyId, string branchId, string periodId)
        {
            using (var dataAccess = new O7DataAccess(DataConnection))
            {
                var parameter = new O7Parameter();
                parameter.Add("COMPANY", companyId);
                parameter.Add("BRANCH", branchId);
                parameter.Add("YEAR", periodId);
                return dataAccess.ExecuteFunction<int>("ADVISORY_PERIOD.ACTIVATE_YEAR", parameter) != 0;
            }
        }

        public bool OpenPeriod(string companyId, string branchId, string periodId)
        {
            using (var dataAccess = new O7DataAccess(DataConnection))
            {
                var parameter = new O7Parameter();
                parameter.Add("p_company", companyId);
                parameter.Add("p_branch", branchId);
                parameter.Add("p_period_id", periodId);
                return dataAccess.ExecuteFunction<int>("ADVISORY_PERIOD.active_period", parameter) != 0;
            }
        }

        public bool ClosePeriod(string companyId, string branchId, string periodId)
        {
            using (var dataAccess = new O7DataAccess(DataConnection))
            {
                var parameter = new O7Parameter();
                parameter.Add("p_company", companyId);
                parameter.Add("p_branch", branchId);
                parameter.Add("p_period_id", periodId);
                return dataAccess.ExecuteFunction<int>("ADVISORY_PERIOD.close_period", parameter) != 0;
            }
        }
    }
}