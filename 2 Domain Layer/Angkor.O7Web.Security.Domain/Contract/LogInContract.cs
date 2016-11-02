// Create by Felix A. Bueno

using Angkor.O7Framework.Web;
using Angkor.O7Web.Interface.Security.Model;

namespace Angkor.O7Web.Security.Domain.Contract
{
    public struct LogInContract
    {
        public bool Success { get; }
        public string MessageError { get; }
        public LogInViewModel ViewModel { get; }

        public LogInContract(bool success, string messageError, LogInViewModel viewModel)
        {
            Success = success;
            MessageError = messageError;
            ViewModel = viewModel;
        }
    }
}