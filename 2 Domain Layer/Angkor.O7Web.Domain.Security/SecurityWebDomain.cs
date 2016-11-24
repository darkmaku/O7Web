// Create by Felix A. Bueno

using System;
using System.Collections.Generic;
using Angkor.O7Framework.Infrastructure;
using Angkor.O7Web.Common.Security.Entity;
using Angkor.O7Web.Data.Security;
using Oracle.ManagedDataAccess.Client;

namespace Angkor.O7Web.Domain.Security
{
    public class SecurityWebDomain : O7Domain
    {
        private InformationDataService _dataService;

        public SecurityWebDomain(string login, string password) : base(login, password)
        {
            _dataService = new InformationDataService(Login, Password);
        }

        public O7ResponseContract<List<Module>> ListModules(string companyId, string branchId)
        {
            var contract = new O7ResponseContract<List<Module>>();
            try
            {
                var modules = _dataService.ListModules(companyId, branchId);
                contract.SetResponse(modules);
            }
            catch (OracleException exception)
            {
                contract.ErrorCode = 401;
                contract.ErrorMessage = exception.Message;
            }
            catch (Exception exception)
            {
                contract.ErrorCode = 400;
                contract.ErrorMessage = exception.Message;
            }
            return contract;
        }
    }
}