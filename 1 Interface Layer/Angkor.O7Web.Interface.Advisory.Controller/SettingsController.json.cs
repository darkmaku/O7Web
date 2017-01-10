// Create by Felix A. Bueno

using System.Net;
using System.Web.Mvc;
using Angkor.O7Framework.Web.WebResult;
using Angkor.O7Web.Domain.Advisory;
using Angkor.O7Web.Domain.Common.AdvisoryComponents;

namespace Angkor.O7Web.Interface.Advisory.Controller
{
    public partial class SettingsController
    {
        [HttpPost]
        public JsonResult PeriodsAvalible()
        {
            var domain = BasicFunction.InitialMethod<PeriodJsonDomain, FlowAdvisory>(User);
            //var domain = new PeriodJsonDomain(User);
            return O7HttpResult.MakeJsonResult(domain.RecordedPeriods());
        }

        [HttpPost]
        public JsonResult YearsAvalible()
        {
            var domain = BasicFunction.InitialMethod<PeriodJsonDomain, FlowAdvisory>(User);
            //var domain = new PeriodJsonDomain(User);
            return O7HttpResult.MakeJsonResult(domain.ListAvalibleYears());
        }

        [HttpPost]
        public JsonResult OpenYear(string year)
        {
            var domain = BasicFunction.InitialMethod<PeriodJsonDomain, FlowAdvisory>(User);
            //var domain = new PeriodJsonDomain(User);
            return O7HttpResult.MakeJsonResult(domain.ActivateYear(year));
        }

        [HttpPost]
        public JsonResult OpenPeriod(string periodId)
        {
            var domain = BasicFunction.InitialMethod<PeriodJsonDomain, FlowAdvisory>(User);
            //var domain = new PeriodJsonDomain(User);
            return O7HttpResult.MakeJsonResult(domain.OpenPeriod(periodId));
        }

        [HttpPost]
        public JsonResult ClosePeriod(string periodId)
        {
            var domain = BasicFunction.InitialMethod<PeriodJsonDomain, FlowAdvisory>(User);
            //var domain = new PeriodJsonDomain(User);
            return O7HttpResult.MakeJsonResult(domain.ClosePeriod(periodId));
        }
        
    }
}