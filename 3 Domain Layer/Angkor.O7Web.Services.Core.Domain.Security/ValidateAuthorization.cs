// Create by Felix A. Bueno

using Angkor.O7Framework.Utility;
using Newtonsoft.Json.Linq;

namespace Angkor.O7Web.Services.Core.Domain.Security
{
    public class ValidateAuthorization
    {
        public static bool ValidateCredentials(object value)
        {
            var json = JObject.FromObject(value);
            var login = json.Value<string>("Logins");
            var password = json.Value<string>("Password");
            return !string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password);
        }
    }
}