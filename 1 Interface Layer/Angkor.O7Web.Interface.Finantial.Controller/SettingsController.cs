// O7ERP Web created by felix_dev
using System.Web.Mvc;
using Angkor.O7Framework.Web.Base;
using Angkor.O7Framework.Web.WebResult;
using Angkor.O7Web.Comunication;

namespace Angkor.O7Web.Interface.Finantial.Controller
{
    public class SettingsController : O7Controller
    {
        public JsonResult InvoiceDocuments_Populate()
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Name, User.Password);
            var response = domain.AllSeries(User.Company, User.Branch);
            return new O7JsonResult(response);
        }
    }
}