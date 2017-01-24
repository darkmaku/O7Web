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

        public virtual bool AddSeries(string companyId, string branchId, string documentType, string id, string current,
            string max, string min, string @default, string digital)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_company", companyId));
            parameters.Add(O7Parameter.Make("p_branch", branchId));
            parameters.Add(O7Parameter.Make("p_document_type", documentType));
            parameters.Add(O7Parameter.Make("p_id", id));
            parameters.Add(O7Parameter.Make("p_current", current));
            parameters.Add(O7Parameter.Make("p_max", max));
            parameters.Add(O7Parameter.Make("p_min", min));
            parameters.Add(O7Parameter.Make("p_default", @default));
            parameters.Add(O7Parameter.Make("p_digital", digital));
            return DataAccess.ExecuteFunction<int>("O7EXPRESS_PACKAGE_SERIESF.get_seriesF", parameters) == 1;
        }

        public virtual List<InvoiceDocumentCount> AllSeries(string companyId, string branchId)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_company", companyId));
            parameters.Add(O7Parameter.Make("p_branch", branchId));            
            return DataAccess.ExecuteFunction<InvoiceDocumentCount>("O7EXPRESS_PACKAGE_SERIESF.get_seriesF", parameters, InvoiceDocumentCountMapper.Class);
        }
    

        public virtual List<InvoiceSeries> Series(string companyId, string branchId, string docType)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_cia", companyId));
            parameters.Add(O7Parameter.Make("p_suc", branchId));
            parameters.Add(O7Parameter.Make("p_tip_doc", docType));
            return DataAccess.ExecuteFunction<InvoiceSeries>("finantial_invoice.serie_ext_type", parameters, InvoiceSeriesMapper.Class);
        }

        public virtual List<InvoiceClient> AllClients(string companyId, string branchId, string word)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_cia", companyId));
            parameters.Add(O7Parameter.Make("p_suc", branchId));
            parameters.Add(O7Parameter.Make("p_cadena", word));
            return DataAccess.ExecuteFunction<InvoiceClient>("finantial_invoice.search_client", parameters, InvoiceClientMapper.Class);
        }

        public virtual List<InvoiceDetails> AllInvoices(string companyId, string branchId)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_company", companyId));
            parameters.Add(O7Parameter.Make("p_branch", branchId));
            return DataAccess.ExecuteFunction<InvoiceDetails>("finantial_invoice.invoices", parameters, InvoiceDetailsMapper.Class);
        }

        public virtual List<ProductDetails> AllProducts(string companyId, string branchId, string ratePerception)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_cia", companyId));
            parameters.Add(O7Parameter.Make("p_suc", branchId));
            parameters.Add(O7Parameter.Make("p_tasper", ratePerception));
            return DataAccess.ExecuteFunction<ProductDetails>("finantial_invoice.search_concept_product", parameters, ProductDetailsMapper.Class);
        }




    }    
}