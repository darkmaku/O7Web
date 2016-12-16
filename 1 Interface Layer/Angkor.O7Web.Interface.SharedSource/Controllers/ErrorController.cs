using System;
using System.Web.Mvc;
using Angkor.O7Framework.Web.WebResult;
using Angkor.O7Web.Domain.Common;
using Angkor.O7Web.Interface.SharedSource.Mappers;
using Angkor.O7Web.Interface.SharedSource.ViewModels;

namespace Angkor.O7Web.Interface.SharedSource.Controllers
{    
    public class ErrorController : Controller
    {
        public ActionResult ManagmentError(string code, string companyId, string branchId)
        {
            switch (code)
            {
                case "401":
                    return RedirectToAction("Error401", new {companyId, branchId});
                case "404":
                    return RedirectToAction("Error404", new {companyId, branchId});
                case "500":
                    return RedirectToAction("Error500", new {companyId, branchId});
                default:
                    throw new Exception();
            }
        }

        public ActionResult Error401(string companyId, string branchId)
        {
            var domainContext = new ManagmentWebDomain("CN01", "CN01");
            var response = domainContext.GetSupervisor(companyId, branchId);

            var mapper = new ErrorViewModelMapper();
            mapper.SetSource(response);

            return O7HttpResult.MakeActionResult(response, mapper);
        }

        public ActionResult Error404(string companyId, string branchId)
        {
            var domainContext = new ManagmentWebDomain("CN01", "CN01");
            var response = domainContext.GetSupervisor(companyId, branchId);

            var mapper = new ErrorViewModelMapper();
            mapper.SetSource(response);

            return O7HttpResult.MakeActionResult(response, mapper);
        }

        public ActionResult Error500(string companyId, string branchId)
        {
            var domainContext = new ManagmentWebDomain("CN01", "CN01");
            var response = domainContext.GetSupervisor(companyId, branchId);

            var mapper = new ErrorViewModelMapper();
            mapper.SetSource(response);

            return O7HttpResult.MakeActionResult(response, mapper);
        }
    }
}