using System.Web.Http;
using Angkor.O7Web.Services.Core.Domain;

namespace Angkor.O7Web.Services.Web.Controllers
{
    [RoutePrefix("service/authentication")]
    public class AuthorizationController : ApiController
    {
        [Route("")]
        public IHttpActionResult Authenticate([FromBody] object crendentials)
        {
            var domain = new Authorization(crendentials);
            var result = domain.Authenticate(crendentials);
            return result.Result ? Ok(result.Response) : BadRequest(result.Response);
        }

        [Route("roles")]
        public IHttpActionResult RolesByUser([FromBody] object crendentials)
        {
            var domain = new Authorization(crendentials);
            var result = domain.RolesByUser(crendentials);
            return result.Result ? Ok(result.Response) : BadRequest(result.Response);
        }
    }
}