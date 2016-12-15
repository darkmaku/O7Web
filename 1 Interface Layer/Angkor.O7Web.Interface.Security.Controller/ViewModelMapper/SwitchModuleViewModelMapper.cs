// Create by Felix A. Bueno

using System.Collections.Generic;
using Angkor.O7Framework.Domain.Response;
using Angkor.O7Framework.Web.Utility;
using Angkor.O7Web.Common.Security.Entity;
using Angkor.O7Web.Interface.Security.Model;

namespace Angkor.O7Web.Interface.Security.Controllers.ViewModelMapper
{    
    public class SwitchModuleViewModelMapper : O7ViewModelMapper<SwitchModuleViewModel>
    {
        public override SwitchModuleViewModel MapTarget()
        {
            var currentSource = Source as O7SuccessResponse<IEnumerable<Module>>;
            return currentSource == null ? null : new SwitchModuleViewModel {Modules = currentSource.Value1};
        }
    }
}