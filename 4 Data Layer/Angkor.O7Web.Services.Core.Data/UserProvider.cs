// Create by Felix A. Bueno

using System;
using Angkor.O7Framework.Data;
using Angkor.O7Framework.Data.Common;
using Angkor.O7Framework.Data.Utility;
using Angkor.O7Web.Services.Core.Data.Entity;

namespace Angkor.O7Web.Services.Core.Data
{
    public class UserProvider : Provider
    {
        private readonly Func<O7Row, UserCredential> _funcGetCredential = reader => new UserCredential
        {
            Company = reader.GetValue<string>(0),
            Branch = reader.GetValue<string>(1),
            Login = reader.GetValue<string>(2),
            Name = reader.GetValue<string>(3)
        };

        public UserProvider(string login, string password) : base(login, password)
        {
        }

        public UserCredential[] GetCredentials(string login)
        {
            using (DataAccess = new O7DataAccess(DatabaseConnection))
            {
                var parameter = new O7Parameter();
                parameter.Add("LOGIN", login);
                return DataAccess.ExecuteFunction("CONSULTAS.LISTAR_USUARIO", parameter, _funcGetCredential);
            }
        }
    }
}