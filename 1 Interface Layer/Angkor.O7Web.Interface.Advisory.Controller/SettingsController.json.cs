// Create by Felix A. Bueno

using System.Web.Mvc;
using Angkor.O7Framework.Web.WebResult;
using Angkor.O7Web.Domain.Advisory;

namespace Angkor.O7Web.Interface.Advisory.Controller
{
    public partial class SettingsController
    {
        [HttpPost]
        public JsonResult PeriodsAvalible()
        {
            var domain = new PeriodJsonDomain(User);
            return O7HttpResult.MakeJsonResult(domain.RecordedPeriods());
        }

        [HttpPost]
        public JsonResult YearsAvalible()
        {
            var domain = new PeriodJsonDomain(User);
            return O7HttpResult.MakeJsonResult(domain.ListAvalibleYears());
        }

        [HttpPost]
        public JsonResult OpenPeriod(string periodId)
        {
            var domain = new PeriodJsonDomain(User);
            return O7HttpResult.MakeJsonResult(domain.ActivatePeriod(periodId));
        }
    }
}