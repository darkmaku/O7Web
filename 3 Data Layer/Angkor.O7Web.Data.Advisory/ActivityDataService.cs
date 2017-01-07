// Create by Felix A. Bueno

using System.Collections.Generic;
using Angkor.O7Framework.Data;
using Angkor.O7Framework.Data.Common;
using Angkor.O7Web.Common.Advisory.Entity;
using Angkor.O7Web.Data.Advisory.DataMapper;

namespace Angkor.O7Web.Data.Advisory
{
    public class ActivityDataService : O7DataAccessService
    {
        public ActivityDataService(string login, string password) : base(login, password)
        {
        }
        
        public bool InsertActivity(string companyId, string branchId, string centerCostId, string periodId, string activityStart, string activityDescription)
        {
            using (var dataAccess = new O7DataAccess(DataConnection))
            {
                var parameter = new O7Parameter();
                parameter.Add("p_company", companyId);
                parameter.Add("p_branch", branchId);
                parameter.Add("p_cost_center", centerCostId);
                parameter.Add("p_period_id", periodId);
                parameter.Add("p_activity_start", activityStart);
                parameter.Add("p_description", activityDescription);
                return dataAccess.ExecuteFunction<int>("advisory_activity.insert_activity", parameter) != 0;
            }
        }

        public List<Activity> ListActivities(string companyId, string branchId, string startDate, string endDate)
        {
            using (var dataAccess = new O7DataAccess(DataConnection))
            {
                var parameter = new O7Parameter();
                parameter.Add("p_company", companyId);
                parameter.Add("p_branch", branchId);
                parameter.Add("p_start_date", startDate);
                parameter.Add("p_end_date", endDate);                
                return dataAccess.ExecuteFunction<Activity>("advisory_activity.list_activities", parameter, typeof(ActivityDataMapper));
            }
        }

        public List<ActivityReport> ListActivityReports(string companyId, string branchId, string workerId,
            string workerName, string workerLastName, string workerSecondLastName, string costCenterId, 
            string startActivity, string endActivity){
            using (var dataAccess = new O7DataAccess(DataConnection))
            {
                var parameter = new O7Parameter();
                parameter.Add("p_company", companyId);
                parameter.Add("p_branch", branchId);
                parameter.Add("p_worker_id", workerId);
                parameter.Add("p_worker_name", workerName);
                parameter.Add("p_worker_last_name", workerLastName);
                parameter.Add("p_worker_second_last_name", workerSecondLastName);
                parameter.Add("p_cost_center_id", costCenterId);
                parameter.Add("p_start_date", startActivity);
                parameter.Add("p_end_date", endActivity);
                return dataAccess.ExecuteFunction<ActivityReport>("advisory_activity.list_activities_by_worker", parameter, typeof(ActivityReportDataMapper));
            }
        }
    }
}