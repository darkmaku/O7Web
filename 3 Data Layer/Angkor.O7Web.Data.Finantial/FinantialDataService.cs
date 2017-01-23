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

        public virtual List<InvoiceDocumentType> DocumentTypes()
        {
            return DataAccess.ExecuteFunction<InvoiceDocumentType>("finantial_invoice.document_type", O7DbParameterCollection.Make, InvoiceDocumentTypeMapper.Class);
        }

        public virtual bool UpdateSeries(string companyId, string branchId, string documentType, string id, string current,
            string max, string min, string @default, string prefix, string idUpdate, string documentTypeUpdate)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_company", companyId));
            parameters.Add(O7Parameter.Make("p_branch", branchId));
            parameters.Add(O7Parameter.Make("p_document_type", documentType));
            parameters.Add(O7Parameter.Make("p_id", id));
            parameters.Add(O7Parameter.Make("p_min", min));
            parameters.Add(O7Parameter.Make("p_max", max));
            parameters.Add(O7Parameter.Make("p_current", current));
            parameters.Add(O7Parameter.Make("p_default", @default));
            parameters.Add(O7Parameter.Make("p_prefix", prefix));
            parameters.Add(O7Parameter.Make("p_document_type_new", documentTypeUpdate));
            parameters.Add(O7Parameter.Make("p_id_new", idUpdate));
            return DataAccess.ExecuteFunction<int>("O7EXPRESS_PACKAGE_SERIESF.update_serieF", parameters) == 1;
        }

        public virtual bool AddSeries(string companyId, string branchId, string documentType, string id, string current,
            string max, string min, string @default, string prefix)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_company", companyId));
            parameters.Add(O7Parameter.Make("p_branch", branchId));
            parameters.Add(O7Parameter.Make("p_document_type", documentType));
            parameters.Add(O7Parameter.Make("p_id", id));
            parameters.Add(O7Parameter.Make("p_min", min));
            parameters.Add(O7Parameter.Make("p_max", max));
            parameters.Add(O7Parameter.Make("p_current", current));
            parameters.Add(O7Parameter.Make("p_default", @default));
            parameters.Add(O7Parameter.Make("p_prefix", prefix));
            return DataAccess.ExecuteFunction<int>("O7EXPRESS_PACKAGE_SERIESF.insert_newserieF", parameters) == 1;
        }

        public virtual List<InvoiceDocumentCount> AllSeries(string companyId, string branchId)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_company", companyId));
            parameters.Add(O7Parameter.Make("p_branch", branchId));            
            return DataAccess.ExecuteFunction<InvoiceDocumentCount>("O7EXPRESS_PACKAGE_SERIESF.get_seriesF", parameters, InvoiceDocumentCountMapper.Class);
        }
    }    
}