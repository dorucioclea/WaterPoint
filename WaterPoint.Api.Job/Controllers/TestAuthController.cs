using System.Net.Http;
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
            return Ok("auth working");
        }
    }
}
