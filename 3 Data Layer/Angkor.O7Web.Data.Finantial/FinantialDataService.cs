// O7ERP Web created by felix_dev
using System.Collections.Generic;
using Angkor.O7Framework.Common.Model;
using Angkor.O7Framework.Data.Tool;
using Angkor.O7Framework.Infrastructure.Data;
using Angkor.O7Web.Common.Finantial.Entity;
using Angkor.O7Web.Data.Finantial.DataMapper;

namespace Angkor.O7Web.Data.Finantial
{
    public class FinantialDataService : O7AbstractData
    {
        public FinantialDataService(string user, string password) : base(user, password)
        {
        }

        public List<InvoiceDocumentCount> AllSeries(string companyId, string branchId)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_company", companyId));
            parameters.Add(O7Parameter.Make("p_branch", branchId));            
            return DataAccess.ExecuteFunction<InvoiceDocumentCount>("O7EXPRESS_PACKAGE_SERIESF.get_seriesF", parameters, InvoiceDocumentCountMapper.Class);
        }
    }    
}