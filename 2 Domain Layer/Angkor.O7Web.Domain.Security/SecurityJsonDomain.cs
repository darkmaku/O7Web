// Create by Felix A. Bueno

using System;
using Angkor.O7Framework.Infrastructure;
using Angkor.O7Framework.Utility;
using Angkor.O7Web.Data.Security;
using Oracle.ManagedDataAccess.Client;

namespace Angkor.O7Web.Domain.Security
{
    public class SecurityJsonDomain : O7Domain
    {
        private InformationDataService _dataService;

        public SecurityJsonDomain(string login, string password) : base(login, password)
        {
            _dataService = new InformationDataService(Login, Password);
        }

        public O7ResponseContract<string> ListCompanies()
        {
            var contract = new O7ResponseContract<string>();
            try
            {
                var companies = _dataService.ListCompanies();
                var companiesSerializaded = O7JsonSerealizer.Serialize(companies);
                contract.SetResponse(companiesSerializaded);
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

        public O7ResponseContract<string> ListBranches(string companyId)
        {
            var contract = new O7ResponseContract<string>();
            try
            {
                var companies = _dataService.ListBranches(companyId);
                var companiesSerialized = O7JsonSerealizer.Serialize(companies);
                contract.SetResponse(companiesSerialized);
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