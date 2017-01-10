using System;
using Angkor.O7Framework.Domain;
using Angkor.O7Framework.Infrastructure;
using Angkor.O7Framework.Web.Security;

namespace Angkor.O7Web.Domain.Common.AdvisoryComponents
{
    public class BasicFunction
    {
        public static TClass InitialMethod<TClass,TFlowAdvisory>(params object[] parametros) 
            where TClass: class where TFlowAdvisory: O7AbstractDomain
        {
            var x = O7DomainAccess.MakeInstance<TClass, TFlowAdvisory>(parametros);
            return x;
        }        
    }
}
