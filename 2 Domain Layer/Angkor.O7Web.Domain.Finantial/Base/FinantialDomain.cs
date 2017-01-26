// O7ERP Web created by felix_dev
using Angkor.O7Framework.Common.Model;
using Angkor.O7Framework.Infrastructure;
using Angkor.O7Web.Data.Finantial;

namespace Angkor.O7Web.Domain.Finantial.Base
{
    public abstract class FinantialDomain
    {
        public FinantialDataService FinantialDataService { get; private set; }

        protected FinantialDomain(string login, string password)
        {
            FinantialDataService = O7DataInstanceMaker.MakeInstance<FinantialDataService>(new object[] { login, password });
        }

        public abstract O7Response DocumentTypes();

        public abstract O7Response AllSeries(string companyId, string branchId);

        public abstract O7Response AddSeries(string companyId, string branchId, string documentType, string id, string current,
            string max, string min, string @default, string digital);

        public abstract O7Response AllClients(string companyId, string branchId, string word);
        public abstract O7Response AllInvoices(string companyId, string branchId,string filter);
        public abstract O7Response Concepts(string companyId, string branchId, string percepcionTasa);
        public abstract O7Response Series(string companyId, string branchId, string docType);
        public abstract O7Response Cco(string companyId, string branchId);
        public abstract O7Response CondSells();


        public abstract O7Response AddInvoice(string companyId, string branchId,
            string documentType, string serie,
            string currency, string documentDate,
            string documentExpiration, string clienteCode
            , string codTax, string clientName
            , string invoiceAddress, string clientId, string glosa,
            string sellType, string language,
            string condSell, string payment,
            string bussinessline, string finantialcod,
            string telephone, string seller,
            string employeeId, string perception,
            string donate, string documentTypeRef,
            string documentIdRef, string documentOC,
            string guiRem, string addressId, string serieExtRef, string nroDoceExt);

        public abstract O7Response getExpirationDate(string companyId, string branchId, string payment, string documentDate);
        public abstract O7Response GetInvoice(string companyId, string branchId, string documentType, string documentId);

        public abstract O7Response GetInvoiceDetail(string companyId, string branchId, string documentType, string documentId);

        public abstract O7Response documentInformation(string companyId, string branchId, string documentType);

        public abstract O7Response GeneratePDF(string companyId, string branchId, string documentType, string documentId);

        public abstract O7Response UpdateInvoice(string companyId, string branchId,
            string documentType, string documentId,
            string currency, string documentDate,
            string documentExpiration, string clienteCode
            , string codTax, string porTax, string clientName
            , string invoiceAddress, string clientId, string glosa,
            string sellType, string language,
            string condSell, string payment,
            string bussinessline, string finantialcod,
            string telephone, string seller,
            string employeeId, string perception,
            string donate, string documentTypeRef,
            string documentIdRef, string documentOC,
            string guiRem, string addressId,
            string serieExtRef, string nroExtRef);
        public abstract O7Response ClientDefaultValues(string companyId, string branchId, string clientCode);
        public abstract O7Response AddInvoiceDetail(string companyId, string branchId,
            string documentType, string documentId,
            string conceptId, string observacion,
            string cantidad, string unitValue,
            string taxId, string perception,
            string ccoId);

        public abstract O7Response SellTypes();

        public abstract O7Response Payments(string cod_sell);

        public abstract O7Response FinantialCodes();

        public abstract O7Response Sellers(string companyId, string branchId);

        public abstract O7Response BussinessLine(string companyId, string branchId);

        public abstract O7Response InvoiceAdresses(string companyId, string branchId, string clientId);

        public abstract O7Response Currencies();

        public abstract O7Response Languages();

        public abstract O7Response Taxes();

        public abstract O7Response Perceptions();
    }
}