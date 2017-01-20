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

        public JsonResult Invoices_Populate()
        {
            var domain = ProxyDomain.Instance.InvoiceDomain(User.Identity.Name, User.Password);
            var response = domain.AllInvoices(User.Company, User.Branch);
            return new O7JsonResult(response);
        }



    }
}