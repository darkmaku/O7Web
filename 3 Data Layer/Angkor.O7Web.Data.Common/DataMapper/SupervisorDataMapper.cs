// Create by Felix A. Bueno

using Angkor.O7Framework.Data.Utility;
using Angkor.O7Web.Common.Entity;

namespace Angkor.O7Web.Data.Common.DataMapper
{
    public class SupervisorDataMapper : O7DataMapper<Supervisor>
    {
        public override Supervisor MapTarget()
        => new Supervisor { Name = Source.GetValue<string>(2), Phone = Source.GetValue<string>(3), Email = Source.GetValue<string>(4) };
    }
}