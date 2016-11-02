// Create by Felix A. Bueno

using Angkor.O7Web.Interface.Security.Model;
using Angkor.O7Web.Security.Domain.Contract;

namespace Angkor.O7Web.Security.Domain.Service
{
    public interface SecurityDomainService
    {
        LogInContract ValidateUser(LogInViewModel model);        
    }
}