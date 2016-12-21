// Create by Felix A. Bueno

using Angkor.O7Framework.Domain;
using Angkor.O7Framework.Domain.Response;
using Angkor.O7Framework.Utility;
using Angkor.O7Framework.Web.Security;
using Angkor.O7Web.Data.Advisory;

[assembly: O7DomainException]
namespace Angkor.O7Web.Domain.Advisory
{
    public class PeriodJsonDomain
    {
        private readonly PeriodDataService _dataService;
        private readonly O7Principal _principal;

        public PeriodJsonDomain(O7Principal principal) 
            : this(principal.Identity.Name, principal.Password)
        {
            _principal = principal;
        }

        public PeriodJsonDomain(string login, string password)
        {
            _dataService = new PeriodDataService(login, password); 
        }

        public O7Response RecordedPeriods()
        {
            var periods = _dataService.ListPeriods(_principal.Company, _principal.Branch);
            var periodsSerialized = O7JsonSerealizer.Serialize(periods);
            return O7SuccessResponse.MakeResponse(periodsSerialized);
        }

        public O7Response ListAvalibleYears()
        {
            var years = _dataService.ListAvalibleYears(_principal.Company, _principal.Branch);
            var yearsSerialized = O7JsonSerealizer.Serialize(years);
            return O7SuccessResponse.MakeResponse(yearsSerialized);
        }

        public O7Response ActivatePeriod(string periodId)
        {
            var response = _dataService.ActivatePeriod(_principal.Company, _principal.Branch, periodId);
            var responseSerialized = O7JsonSerealizer.Serialize(response);
            return O7SuccessResponse.MakeResponse(responseSerialized);
        }
    }
}