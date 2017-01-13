// Create by Felix A. Bueno

using Angkor.O7Web.Data.Security;

namespace Angkor.O7Web.Domain.Finantial
{
    public class SecurityJsonDomain
    {
        private readonly SecurityDataService _dataService;

        public SecurityJsonDomain(string login, string password)
        {
            _dataService = new SecurityDataService(login, password);
        }
    }
}