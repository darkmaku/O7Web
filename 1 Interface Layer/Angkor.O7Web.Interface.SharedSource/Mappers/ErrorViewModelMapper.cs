// Create by Felix A. Bueno

using Angkor.O7Framework.Domain.Response;
using Angkor.O7Framework.Web.Utility;
using Angkor.O7Web.Common.Entity;
using Angkor.O7Web.Interface.SharedSource.ViewModels;

namespace Angkor.O7Web.Interface.SharedSource.Mappers
{
    public class ErrorViewModelMapper : O7ViewModelMapper<ErrorViewModel>
    {
        public override ErrorViewModel MapTarget()
        {
            var currentSource = Source as O7SuccessResponse<Supervisor>;
            return currentSource == null
                ? null
                : new ErrorViewModel
                {
                    Name = currentSource.Value1.Name,
                    Phone = currentSource.Value1.Phone,
                    Email = currentSource.Value1.Email
                };
        }
    }
}