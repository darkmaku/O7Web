// Create by Felix A. Bueno

using Angkor.O7Framework.Data.Utility;
using Angkor.O7Web.Common.Entity;

namespace Angkor.O7Web.Data.Common.DataMapper
{
    public class CentroCostoDataMapper : O7DataMapper<CentroCosto>
    {
        public override CentroCosto MapTarget()
        => new CentroCosto { Id = Source.GetValue<string>(0), Description= Source.GetValue<string>(1) };
    }
}