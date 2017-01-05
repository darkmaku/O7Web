﻿using System.Runtime.Remoting.Messaging;
using System.Threading;
using Angkor.O7Framework.Domain;
using Angkor.O7Framework.Infraestructure;

namespace Angkor.O7Web.Domain.Security.Components
{
    public class SecurityInterface
    {
        public static TClass Exec<TClass, TDomain>(params object[] parameters) 
            where TDomain : O7AbstractDomain where TClass : class
        {
            return O7DomainAccess.MakeInstance<TClass, TDomain>();
        }
    }
}
