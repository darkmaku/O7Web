// Create by Felix A. Bueno

using System;
using System.Collections.Specialized;
using Angkor.O7Framework.Web.Base;


namespace Angkor.O7Web.Interface.Security.Controllers
{
    public partial class AuthenticationController : O7Controller
    {
        //TODO: Add dependency injections

        private Tuple<string, string, string, string> get_values_login_post(NameValueCollection formCollection)
        {
            var login = formCollection["logIn"];
            var password = formCollection["password"];
            var company = formCollection["company"];
            var branch = formCollection["branch"];
            return Tuple.Create(login, password, company, branch);
        }
    }
}