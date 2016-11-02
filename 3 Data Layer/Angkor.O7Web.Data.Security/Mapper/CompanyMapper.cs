// Create by Felix A. Bueno

using Angkor.O7Framework.Data.Utility;
using Angkor.O7Web.Common.Security.Entity;

namespace Angkor.O7Web.Data.Security.Mapper
{
    public class CompanyMapper : O7Mapper<Company>
    {
        public override Company Map()
        {
            var result = new Company();
            result.Id = O7Row.GetValue<string>(0);
            result.Description = O7Row.GetValue<string>(1);
            return result;
        }
    }
}