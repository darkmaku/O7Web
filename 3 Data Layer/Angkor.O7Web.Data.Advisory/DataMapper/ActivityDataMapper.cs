// Create by Felix A. Bueno

using Angkor.O7Framework.Data.Utility;
using Angkor.O7Web.Common.Advisory.Entity;

namespace Angkor.O7Web.Data.Advisory.DataMapper
{
    public class ActivityDataMapper : O7DataMapper<Activity>
    {
        public override Activity MapTarget()
            => new Activity {Title = Source.GetValue<string>(0), Date = Source.GetValue<string>(1)};
    }
}