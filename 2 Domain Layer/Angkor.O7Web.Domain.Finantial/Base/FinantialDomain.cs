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