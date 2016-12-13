// Create by Felix A. Bueno
namespace Angkor.O7Web.Interface.Security.Controllers.Transfer
{
    public class CredentialCookie
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }

        public CredentialCookie()
        {
        }

        public CredentialCookie(string login, string password, string companyId, string branchId)
        {
            Login = login;
            Password = password;
            CompanyId = companyId;
            BranchId = branchId;
        }
    }
}