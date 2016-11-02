// Create by Felix A. Bueno

using System;
using Angkor.O7Framework.Contract;
using Angkor.O7Framework.Utility;
using Angkor.O7Web.Services.Common.Exception;
using Angkor.O7Web.Services.Core.Data;

namespace Angkor.O7Web.Services.Core.Domain
{
    public class Authorization
    {
        private readonly string _login;
        private readonly string _password;

        public Authorization(object json)
        {
            _login = O7JsonProperty.GetStringValue(json, "Login");
            _password = O7JsonProperty.GetStringValue(json, "Password");
            if (string.IsNullOrWhiteSpace(_login) || string.IsNullOrWhiteSpace(_password))
                throw JsonException.MakeInvalidStructure;
        }

        public O7DomainContract Authenticate(object crendentials)
        {
            try
            {
                var provider = new UserProvider(_login, _password);
                return new O7DomainContract(true, provider.GetCredentials(_login));
            }
            catch (Exception exception)
            {
                return new O7DomainContract(false, exception.Message);
            }
        }

        public O7DomainContract RolesByUser(object credentials)
        {
            try
            {
                var company = O7JsonProperty.GetStringValue(credentials, "Company");
                var branch = O7JsonProperty.GetStringValue(credentials, "Branch");
                var user = O7JsonProperty.GetStringValue(credentials, "User");
                var provider = new RoleProvider(_login, _password);
                return new O7DomainContract(true, provider.GetRoles(company, branch, user));
            }
            catch (Exception exception)
            {
                return new O7DomainContract(false, exception.Message);
            }
        }
    }
}