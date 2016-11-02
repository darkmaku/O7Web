// Create by Felix A. Bueno

namespace Angkor.O7Web.Security.Domain.Service
{
    public interface SecurityJsonService
    {
        string ListCompanies(string username, string password);
        string ListBranches(string companyId);
    }
}