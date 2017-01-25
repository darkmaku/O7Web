// O7ERP Web created by felix_dev

using System.Web.Mvc;
using Angkor.O7Framework.Web.Base;
using Angkor.O7Framework.Web.WebResult;
using Angkor.O7Web.Comunication;

namespace Angkor.O7Web.Interface.Finantial.Controller
{
    public class InvoiceController : O7Controller
    {
        public JsonResult Insert_ClientSearch(string id, string name, string identifier)
        {
            return null;
        }

        public ActionResult Insert()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Invoices_Populate(string filter)
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.AllInvoices(User.Company, User.Branch,filter);
            return new O7JsonResult(response);
        }

        public JsonResult Insert_Invoice(string documentType, string serie,
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
                                            string serieExtRef, string nroDoceExt)
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.AddInvoice(User.Company, User.Branch, 
                                            documentType, serie,
                                             currency, documentDate,
                                             documentExpiration, clienteCode
                                            , codTax, clientName
                                            , invoiceAddress, clientId, glosa,
                                             sellType, language,
                                             condSell, payment,
                                             bussinessline, finantialcod,
                                             telephone, seller,
                                             employeeId, perception,
                                             donate, documentTypeRef,
                                             documentIdRef, documentOc,
                                             guiRem, addressId,serieExtRef,nroDoceExt);
            return new O7JsonResult(response);
        }


        public JsonResult GetConcepts(string ratePerception)
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.Concepts(User.Company, User.Branch, ratePerception);
            return new O7JsonResult(response);
        }
        public JsonResult GetCenterCost()
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.Cco(User.Company, User.Branch);
            return new O7JsonResult(response);
        }
        public JsonResult Get_Clients(string filter)
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.AllClients(User.Company, User.Branch, filter);
            return new O7JsonResult(response);
        }

        public JsonResult GetCondSells()
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.CondSells();
            return new O7JsonResult(response);
        }

        public JsonResult GetSellTypes()
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.SellTypes();
            return new O7JsonResult(response);
        }

        public JsonResult GetPayments(string cond_sell)
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.Payments(cond_sell);
            return new O7JsonResult(response);
        }

        public JsonResult GetFinantialCodes()
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.FinantialCodes();
            return new O7JsonResult(response);
        }

        public JsonResult GetSellers()
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.Sellers(User.Company,User.Branch);
            return new O7JsonResult(response);
        }

        public JsonResult GetBussinessLine()
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.BussinessLine(User.Company, User.Branch);
            return new O7JsonResult(response);
        }

        public JsonResult GetInvoiceAdresses(string clientId)
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.InvoiceAdresses(User.Company, User.Branch,clientId);
            return new O7JsonResult(response);
        }

        public JsonResult GetDocumentTypes()
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.DocumentTypes();
            return new O7JsonResult(response);
        }

        public JsonResult GetSeries(string doctype)
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.Series(User.Company,User.Branch,doctype);
            return new O7JsonResult(response);
        }

        public JsonResult GetCurrencies()
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.Currencies();
            return new O7JsonResult(response);
        }

        public JsonResult GetLanguages()
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.Languages();
            return new O7JsonResult(response);
        }

        public JsonResult GetTaxes()
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.Taxes();
            return new O7JsonResult(response);
        }


        public JsonResult GetPerception()
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.Perceptions();
            return new O7JsonResult(response);
        }
       



    }
}