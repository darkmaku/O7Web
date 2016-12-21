// Create by Felix A. Bueno

using Angkor.O7Framework.Data.Utility;
using Angkor.O7Web.Common.Advisory.Entity;

namespace Angkor.O7Web.Data.Advisory.DataMapper
{
    public class PeriodDataMapper : O7DataMapper<Period>
    {
        public override Period MapTarget()
            => new Period {Id = Source.GetValue<int>(0), State = Source.GetValue<string>(1), Owner = Source.GetValue<string>(2), Creation = Source.GetValue<string>(3) };
    }
}