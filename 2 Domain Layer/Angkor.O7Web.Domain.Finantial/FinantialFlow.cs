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

        public override O7Response GetInvoice(string companyId, string branchId, string documentType, string documentId)
        {
            var result = FinantialDataService.GetInvoice(companyId, branchId, documentType,documentId);
            var seriesSerialized = O7JsonSerealizer.Serialize(result);
            return O7SuccessResponse.MakeResponse(seriesSerialized);
        }

        public override O7Response GetInvoiceDetail(string companyId, string branchId, string documentType, string documentId)
        {
            var result = FinantialDataService.GetInvoiceDetail(companyId, branchId, documentType, documentId);
            var seriesSerialized = O7JsonSerealizer.Serialize(result);
            return O7SuccessResponse.MakeResponse(seriesSerialized);
        }

        public override O7Response AllClients(string companyId, string branchId, string word)
        {
            var client = FinantialDataService.AllClients(companyId, branchId, word);
            var clientSerialized = O7JsonSerealizer.Serialize(client);
            return O7SuccessResponse.MakeResponse(clientSerialized);
        }

        public override O7Response GeneratePDF(string companyId, string branchId, string documentType, string documentId)
        {
            var client = FinantialDataService.GeneratePDF(companyId, branchId,documentType,documentId);
            var clientSerialized = O7JsonSerealizer.Serialize(client);
            return O7SuccessResponse.MakeResponse(clientSerialized);
        }

        public override O7Response GenerateReporte(string companyId, string branchId, string documentType, string documentId)
        {
            var client = FinantialDataService.GenerateReporte(companyId, branchId, documentType, documentId);
            var clientSerialized = O7JsonSerealizer.Serialize(client);
            return O7SuccessResponse.MakeResponse(clientSerialized);
        }

        public override O7Response AllInvoices(string companyId, string branchId,string filter)
        {
            var invoices = FinantialDataService.AllInvoices(companyId, branchId,filter);
            var invoicesSerialized = O7JsonSerealizer.Serialize(invoices);
            return O7SuccessResponse.MakeResponse(invoicesSerialized);
        }

        public override O7Response UpdateInvoice(string companyId, string branchId,
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
                                       string serieExtRef, string nroExtRef)
        {
            var invoices = FinantialDataService.UpdateInvoiceHead(companyId, branchId,
                                         documentType, documentId,
                                        currency, documentDate,
                                        documentExpiration, clienteCode
                                       , codTax, porTax, clientName
                                       , invoiceAddress, clientId, glosa,
                                        sellType, language,
                                        condSell, payment,
                                        bussinessline, finantialcod,
                                        telephone, seller,
                                        employeeId, perception,
                                        donate, documentTypeRef,
                                        documentIdRef, documentOC,
                                        guiRem, addressId,
                                        serieExtRef, nroExtRef);
            var invoicesSerialized = O7JsonSerealizer.Serialize(invoices);
            return O7SuccessResponse.MakeResponse(invoicesSerialized);
        }

        public override O7Response AddInvoice(string companyId, string branchId,
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
                                            string documentIdRef, string documentOc,
                                            string guiRem, string addressId,
                                            string serieExtRef,string nroDoceExt)
        {
            var invoices = FinantialDataService.AddInvoice(companyId,  branchId,
                                             documentType,  serie,
                                             currency,  documentDate,
                                             documentExpiration,  clienteCode
                                            ,  codTax,  clientName
                                            ,  invoiceAddress,  clientId,  glosa,
                                             sellType,  language,
                                             condSell,  payment,
                                             bussinessline,  finantialcod,
                                             telephone,  seller,
                                             employeeId,  perception,
                                             donate,  documentTypeRef,
                                             documentIdRef,  documentOc,
                                             guiRem,  addressId,serieExtRef,nroDoceExt);
            var invoicesSerialized = O7JsonSerealizer.Serialize(invoices);
            return O7SuccessResponse.MakeResponse(invoicesSerialized);
        }

        public override O7Response AddInvoiceDetail(string companyId, string branchId,
                                    string documentType, string documentId,
                                    string conceptId, string observacion,
                                    string cantidad, string unitValue,
                                    string taxId, string perception,
                                    string ccoId)
        {
            var invoices = FinantialDataService.AddInvoiceDetail( companyId,  branchId,
                                     documentType,  documentId,
                                     conceptId,  observacion,
                                     cantidad,  unitValue,
                                     taxId,  perception,
                                     ccoId);
            var invoicesSerialized = O7JsonSerealizer.Serialize(invoices);
            return O7SuccessResponse.MakeResponse(invoicesSerialized);
        }

      

        public override O7Response Concepts(string companyId, string branchId, string ratePerception)
        {
            var concepts = FinantialDataService.AllConcepts(companyId, branchId, ratePerception);
            var conceptsSerialized = O7JsonSerealizer.Serialize(concepts);
            return O7SuccessResponse.MakeResponse(conceptsSerialized);
        }

        public override O7Response Cco(string companyId, string branchId)
        {
            var cco = FinantialDataService.AllCco(companyId, branchId);
            var ccoSerialized = O7JsonSerealizer.Serialize(cco);
            return O7SuccessResponse.MakeResponse(ccoSerialized);
        }

        public override O7Response ClientDefaultValues(string companyId, string branchId,string clientCode)
        {
            var cco = FinantialDataService.ClientDefaultValues(companyId, branchId, clientCode);
            var ccoSerialized = O7JsonSerealizer.Serialize(cco);
            return O7SuccessResponse.MakeResponse(ccoSerialized);
        }

        public override O7Response documentInformation(string companyId, string branchId, string documentType)
        {
            var cco = FinantialDataService.DocumentInformation(companyId, branchId, documentType);
            var ccoSerialized = O7JsonSerealizer.Serialize(cco);
            return O7SuccessResponse.MakeResponse(ccoSerialized);
        }

        public override O7Response getExpirationDate(string companyId, string branchId, string payment, string documentDate)
        {
            var cco = FinantialDataService.GetFecVto(companyId, branchId, payment,documentDate);
            var ccoSerialized = O7JsonSerealizer.Serialize(cco);
            return O7SuccessResponse.MakeResponse(ccoSerialized);
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

        public override O7Response DeleteDetailInvoice(string companyId,string branchId,
                                    string DocumentType,string DocumentId)
        {
            var selltypes = FinantialDataService.DeleteDetailInvoice(companyId,branchId, DocumentType, DocumentId);
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

        public override O7Response InvoiceAdresses(string companyId, string branchId,string clientId)
        {
            var invoiceadresses = FinantialDataService.AllDirFacs(companyId, branchId,clientId);
            var invoiceadressesSerialized = O7JsonSerealizer.Serialize(invoiceadresses);
            return O7SuccessResponse.MakeResponse(invoiceadressesSerialized);
        }

        public override O7Response Currencies()
        {
            var invoiceadresses = FinantialDataService.AllCurrencies();
            var invoiceadressesSerialized = O7JsonSerealizer.Serialize(invoiceadresses);
            return O7SuccessResponse.MakeResponse(invoiceadressesSerialized);
        }
        public override O7Response Languages()
        {
            var invoiceadresses = FinantialDataService.AllLanguages();
            var invoiceadressesSerialized = O7JsonSerealizer.Serialize(invoiceadresses);
            return O7SuccessResponse.MakeResponse(invoiceadressesSerialized);
        }
        public override O7Response Taxes()
        {
            var invoiceadresses = FinantialDataService.AllTaxes();
            var invoiceadressesSerialized = O7JsonSerealizer.Serialize(invoiceadresses);
            return O7SuccessResponse.MakeResponse(invoiceadressesSerialized);
        }
        public override O7Response Perceptions()
        {
            var invoiceadresses = FinantialDataService.AllPerception();
            var invoiceadressesSerialized = O7JsonSerealizer.Serialize(invoiceadresses);
            return O7SuccessResponse.MakeResponse(invoiceadressesSerialized);
        }



        //tip doc ,serie
        //moneda,idioma
        //impuesto,percepcion
    }
}