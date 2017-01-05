using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Angkor.O7Framework.Domain;
using Angkor.O7Framework.Infraestructure;
using Angkor.O7Framework.Web.Security;

namespace Angkor.O7Web.Domain.Advisory.Components
{
    class BasicFunction
    {
        public static TClass InitialMethod<TClass,TFlowAdvisory>(params object[] parametros) 
            where TClass: class where TFlowAdvisory:O7AbstractDomain
        {
            var x = O7DomainAccess.MakeInstance<TClass, TFlowAdvisory>();
            return x;
        }

        public object InitialMethod<T1, T2>(O7Principal user)
        {
            throw new NotImplementedException();
        }
    }
}
