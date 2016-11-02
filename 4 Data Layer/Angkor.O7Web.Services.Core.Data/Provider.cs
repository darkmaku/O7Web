// Create by Felix A. Bueno

using Angkor.O7Framework.Data;
using Angkor.O7Framework.Data.Utility;

namespace Angkor.O7Web.Services.Core.Data
{
    public abstract class Provider
    {
        protected string DatabaseConnection;
        protected O7DataAccess DataAccess;

        protected Provider(string login, string password)
        {
            DatabaseConnection = O7Provider.DataBaseConection(login, password);
        }
    }
}