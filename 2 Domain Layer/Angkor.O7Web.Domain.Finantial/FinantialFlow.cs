// O7ERP Web created by felix_dev
using Angkor.O7Framework.Common.Model;
using Angkor.O7Framework.Utility;
using Angkor.O7Web.Data.Finantial;
using Angkor.O7Web.Domain.Finantial.Base;

namespace Angkor.O7Web.Domain.Finantial
{
    public class FinantialFlow : FinantialDomain
    {
        public FinantialFlow(string login, string password) : base(login, password)
        {
        }

        public override O7Response DocumentTypes()
        {
            var series = FinantialDataService.DocumentTypes();
            var seriesSerialized = O7JsonSerealizer.Serialize(series);
            return O7SuccessResponse.MakeResponse(seriesSerialized);
        }

        public override O7Response AllSeries(string companyId, string branchId)
        {
            var series = FinantialDataService.AllSeries(companyId, branchId);
            var seriesSerialized = O7JsonSerealizer.Serialize(series);
            return O7SuccessResponse.MakeResponse(seriesSerialized);
        }

        public override O7Response AddSeries(string companyId, string branchId, string documentType, string id, string current,
            string max, string min, string @default, string digital)
        {
            var result = FinantialDataService.AddSeries(companyId, branchId, documentType, id, current, max, min, @default, digital);
            var seriesSerialized = O7JsonSerealizer.Serialize(result);
            return O7SuccessResponse.MakeResponse(seriesSerialized);
        }

        public override O7Response AllClients(string companyId, string branchId, string word)
        {
            var client = FinantialDataService.AllClients(companyId, branchId, word);
            var clientSerialized = O7JsonSerealizer.Serialize(client);
            return O7SuccessResponse.MakeResponse(clientSerialized);
        }

        public override O7Response AllInvoices(string companyId, string branchId)
        {
            var invoices = FinantialDataService.AllInvoices(companyId, branchId);
            var invoicesSerialized = O7JsonSerealizer.Serialize(invoices);
            return O7SuccessResponse.MakeResponse(invoicesSerialized);
        }

        public override O7Response AllProducts(string companyId, string branchId, string ratePerception)
        {
            var products = FinantialDataService.AllProducts(companyId, branchId, ratePerception);
            var productsSerialized = O7JsonSerealizer.Serialize(products);
            return O7SuccessResponse.MakeResponse(productsSerialized);
        }

        public override O7Response Series(string companyId, string branchId, string docType)
        {
            var series = FinantialDataService.Series(companyId, branchId, docType);
            var seriesSerialized = O7JsonSerealizer.Serialize(series);
            return O7SuccessResponse.MakeResponse(seriesSerialized);
        }
        //cond venta,tipventa ,form pago,codfin,vende,line
        public override O7Response CondSells()
        {
            var condsells = FinantialDataService.AllCondSells();
            var condsellsSerialized = O7JsonSerealizer.Serialize(condsells);
            return O7SuccessResponse.MakeResponse(condsellsSerialized);
        }

        public override O7Response SellTypes()
        {
            var selltypes = FinantialDataService.AllSellsTypes();
            var selltypesSerialized = O7JsonSerealizer.Serialize(selltypes);
            return O7SuccessResponse.MakeResponse(selltypesSerialized);
        }

        public override O7Response Payments(string cod_sell)
        {
            var payment = FinantialDataService.AllPayements(cod_sell);
            var paymentSerialized = O7JsonSerealizer.Serialize(payment);
            return O7SuccessResponse.MakeResponse(paymentSerialized);
        }

        public override O7Response FinantialCodes()
        {
            var finantialcodes = FinantialDataService.AllFinantialCodes();
            var finantialcodesSerialized = O7JsonSerealizer.Serialize(finantialcodes);
            return O7SuccessResponse.MakeResponse(finantialcodesSerialized);
        }

        public override O7Response Sellers(string companyId, string branchId)
        {
            var sellers = FinantialDataService.AllSeller(companyId,branchId);
            var sellersSerialized = O7JsonSerealizer.Serialize(sellers);
            return O7SuccessResponse.MakeResponse(sellersSerialized);
        }

        public override O7Response BussinessLine(string companyId, string branchId)
        {
            var bussinesslines = FinantialDataService.AllBusinessLines(companyId, branchId);
            var bussinesslinesSerialized = O7JsonSerealizer.Serialize(bussinesslines);
            return O7SuccessResponse.MakeResponse(bussinesslinesSerialized);
        }
    }
}