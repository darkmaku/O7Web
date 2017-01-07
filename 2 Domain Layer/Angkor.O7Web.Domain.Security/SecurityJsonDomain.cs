// Create by Felix A. Bueno

using System;
using Angkor.O7Framework.Common.Model;
using Angkor.O7Framework.Utility;
using Angkor.O7Web.Data.Security;

namespace Angkor.O7Web.Domain.Security
{
    public class SecurityJsonDomain
    {        
        //TODO: usar una clase en ves de tupla.
        private readonly Tuple<string, string> _credentials;

        public SecurityJsonDomain(string login, string password)
        {
            _credentials = Tuple.Create(login, password);
        }

        public O7Response ListCompanies()
        {
            using (var service = new SecurityDataService(_credentials.Item1,_credentials.Item2))
            {
                var companies = service.ListCompanies();
                var companiesSerialized = O7JsonSerealizer.Serialize(companies);
                return O7SuccessResponse.MakeResponse(companiesSerialized);
            }
        }

        public O7Response ListBranches(string companyId)
        {
            using (var service = new SecurityDataService(_credentials.Item1, _credentials.Item2))
            {
                var companies = service.ListBranches(companyId);
                var companiesSerialized = O7JsonSerealizer.Serialize(companies);
                return O7SuccessResponse.MakeResponse(companiesSerialized);
            }
        }
    }
}