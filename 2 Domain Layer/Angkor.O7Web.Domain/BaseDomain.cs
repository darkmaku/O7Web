// Create by Felix A. Bueno

using System;

namespace Angkor.O7Web.Domain
{
    public abstract class BaseDomain : IDisposable
    {
        protected string Login;
        protected string Password;

        protected BaseDomain(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public void Dispose()
        {
            //TODO: usar colector de basura para limpiar memoria de los acceso a datos.
        }
    }
}