// Create by Felix A. Bueno
using Angkor.O7Framework.Data.Tool;
using Angkor.O7Web.Common.Security.Entity;

namespace Angkor.O7Web.Data.Security.DataMapper
{
    public class ModuleDataMapper : O7DbMapper<Module>
    {                
        public override Module MapTarget()
            => new Module { Title = Source.GetValue<string>(0), Version = Source.GetValue<string>(1), Url = Source.GetValue<string>(2) };
    }
}