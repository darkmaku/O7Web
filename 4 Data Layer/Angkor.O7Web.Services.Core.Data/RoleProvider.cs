// Create by Felix A. Bueno

using System;
using Angkor.O7Framework.Data;
using Angkor.O7Framework.Data.Common;
using Angkor.O7Framework.Data.Utility;
using Angkor.O7Web.Services.Core.Data.Entity;

namespace Angkor.O7Web.Services.Core.Data
{
    public class RoleProvider : Provider
    {
        private readonly Func<O7Row, UserRole> _funcGetRole = reader => new UserRole
        {
            Company = reader.GetValue<string>(0),
            Branch = reader.GetValue<string>(1),
            Nombre = reader.GetValue<string>(2),
            Descripcion = reader.GetValue<string>(3)
        };

        public RoleProvider(string login, string password) : base(login, password)
        {
        }

        public UserRole[] GetRoles(string company, string branch, string userId)
        {
            using (DataAccess = new O7DataAccess(DatabaseConnection))
            {
                var parameter = new O7Parameter();
                parameter.Add("CODCIA", company);
                parameter.Add("CODSUC", branch);
                parameter.Add("NOMBRE", userId);
                return DataAccess.ExecuteFunction("CONSULTAS.LISTAR_ROL_USUARIO", parameter, _funcGetRole);
            }
        }
    }
}