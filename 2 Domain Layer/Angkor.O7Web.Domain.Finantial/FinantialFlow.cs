// O7ERP Web created by felix_dev
using Angkor.O7Framework.Common.Model;
using Angkor.O7Framework.Utility;
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
    }
}