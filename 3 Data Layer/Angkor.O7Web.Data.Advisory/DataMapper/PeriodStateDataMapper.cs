// Create by Felix A. Bueno

using Angkor.O7Framework.Data.Utility;
using Angkor.O7Web.Common.Advisory.Entity;

namespace Angkor.O7Web.Data.Advisory.DataMapper
{
    public class PeriodStateDataMapper : O7DataMapper<Year>
    {
        public override Year MapTarget()
            => new Year {Id = Source.GetValue<int>(0), Description = Source.GetValue<string>(1)};
    }
}