// Create by Felix A. Bueno

using Angkor.O7Framework.Web;
using Angkor.O7Web.Security.Domain;
using Angkor.O7Web.Security.Domain.Service;

namespace Angkor.O7Web.Interface.Security.Controllers
{
    public partial class AuthenticationController : O7Controller
    {
        private readonly SecurityDomainService _domainService;
        private readonly SecurityJsonService _jsonService;

        public AuthenticationController(SecurityDomainService domainService, SecurityJsonService jsonService)
        {
            _domainService = domainService;
            _jsonService = jsonService;
        }

        public AuthenticationController() : this(new SecurityDomain(), new SecurityJson())
        {
        }                
    }
}