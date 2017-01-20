﻿// O7ERP Web created by felix_dev
using System.Web.Mvc;
using Angkor.O7Framework.Utility;
using Angkor.O7Framework.Web.Base;
using Angkor.O7Framework.Web.WebResult;
using Angkor.O7Web.Comunication;

namespace Angkor.O7Web.Interface.Finantial.Controller
{
    public class SettingsController : O7Controller
    {
        public JsonResult InvoiceDocuments_Populate()
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.AllSeries(User.Company, User.Branch);
            return new O7JsonResult(response);
        }

        public JsonResult DocumentTypes()
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.DocumentTypes();
            return new O7JsonResult(response);
        }

        public JsonResult AddSeries(string companyId, string branchId, string documentType, string id, string current,
            string max, string min, string @default, string digital)
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.AddSeries(companyId, branchId, documentType, id, current, max, min, @default, digital);
            return new O7JsonResult(response);
        }

        public ActionResult InvoiceDocuments()
        {
            return View();
        }
    }
}