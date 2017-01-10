using Angkor.O7Framework.Domain;
using Angkor.O7Framework.Infrastructure;

namespace Angkor.O7Web.Domain.Common.SecurityComponents
{
    public class SecurityInterface
    {
        public static TClass Make<TClass, TDomain>(params object[] parameters) 
            where TDomain : O7AbstractDomain where TClass : class
        {
            return O7DomainAccess.MakeInstance<TClass, TDomain>(parameters);
        }
    }
}
