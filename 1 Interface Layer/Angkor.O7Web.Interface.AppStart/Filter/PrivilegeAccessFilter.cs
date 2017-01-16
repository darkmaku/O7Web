// Create by Felix A. Bueno
using System.Web;
using System.Web.Mvc;
using Angkor.O7Framework.Common.Model;
using Angkor.O7Framework.Domain;
using Angkor.O7Framework.Web.HtmlHelper;
using Angkor.O7Framework.Web.Model;
using Angkor.O7Web.Domain.Common;
using Angkor.O7Web.Domain.Security;

namespace Angkor.O7Web.Interface.AppStart.Filter
{
    public class PrivilegeAccessFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var menuId = (string) filterContext.ActionParameters["menuId"];
            var user = (O7Principal) HttpContext.Current.User;
            var argDomain = new object[] {user.Name, user.Password};
            var argFlow = new object[] {user.Name};
            var domain = O7DomainInstanceMaker.MakeInstance<SecurityWebDomain, BasicFlow>(argDomain, argFlow);
            var response = domain.ValidAccess(user.Company, user.Branch, menuId);
            if (response is O7ErrorResponse)
                filterContext.Result = new RedirectResult(LinkHelper.SourceLink("Error", "AuthorizationError"));
            var responseAction = (O7SuccessResponse<string>) response;
            if (responseAction.Value1 == "false")
                filterContext.Result = new RedirectResult(LinkHelper.SourceLink("Error", "AuthorizationError"));
            filterContext.Result.ExecuteResult(filterContext.Controller.ControllerContext);
        }
    }
}