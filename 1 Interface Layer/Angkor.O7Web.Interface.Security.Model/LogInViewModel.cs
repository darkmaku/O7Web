// Create by Felix A. Bueno

using Angkor.O7Framework.Web.Base;

namespace Angkor.O7Web.Interface.Security.Model
{
    public class LogInViewModel : O7ViewModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Message { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }

        public override bool ValidViewModel
        {
            get
            {
                if (string.IsNullOrEmpty(Login))
                {
                    ErrorMessages.Add("El campo de login es requerido");                    
                }
                if (string.IsNullOrEmpty(Password))
                {
                    ErrorMessages.Add("El campo password es requerido");                    
                }
                if (string.IsNullOrEmpty(CompanyId))
                {
                    ErrorMessages.Add("No se eligio correctamente la compañia");                    
                }
                if (string.IsNullOrEmpty(BranchId))
                {
                    ErrorMessages.Add("No se eligio correctamente la sucursal");
                }
                return ErrorMessages.Count <= 0;
            }
        }
    }
}