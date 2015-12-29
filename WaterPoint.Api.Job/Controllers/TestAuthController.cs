using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using WaterPoint.Api.Common.BaseControllers;

namespace WaterPoint.Api.Job.Controllers
{
    [Authorize]
    [RoutePrefix("testauth")]
    public class TestAuthController : BaseOrgnizationContextController
    {
        [Route("")]
        public IHttpActionResult Get()
        {

            var context = Request.GetOwinContext();

            var user = context.Authentication.User;

            var userContextData = user.Claims.First(i => i.Type == ClaimTypes.PrimaryGroupSid).Value;

            var priv = user.Claims.First(i => i.Type == ClaimTypes.Sid).Value;



            return Ok("auth working");
        }
    }
}
