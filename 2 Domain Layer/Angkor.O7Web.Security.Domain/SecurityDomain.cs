// Create by Felix A. Bueno

using System;
using Angkor.O7Framework.Contract;
using Angkor.O7Web.Interface.Security.Model;
using Angkor.O7Web.Security.Domain.Contract;
using Angkor.O7Web.Security.Domain.Service;
using Angkor.O7Web.Services.Core.Data;
using Oracle.ManagedDataAccess.Client;

namespace Angkor.O7Web.Security.Domain
{
    public class SecurityDomain : SecurityDomainService
    {
        public LogInContract ValidateUser(LogInViewModel model)
        {
            try
            {
                throw new Exception();
            }
            catch (OracleException exception)
            {
                if (exception.Number == 1017)
                    return new LogInContract(false, "Usuario o contraseña incorrecto.", model);
                throw;
            }            
        }
    }
}