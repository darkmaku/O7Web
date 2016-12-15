// Create by Felix A. Bueno

using Angkor.O7Framework.Data.Utility;
using Angkor.O7Web.Common.Security.Entity;

namespace Angkor.O7Web.Data.Security.DataMapper
{
    public class BranchDataMapper : O7DataMapper<Branch>
    {
        public override Branch MapTarget()
            => new Branch { Id = Source.GetValue<string>(0), Description = Source.GetValue<string>(1) };
    }
}