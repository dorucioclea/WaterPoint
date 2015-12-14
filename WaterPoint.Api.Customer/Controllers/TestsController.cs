using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WaterPoint.Api.Customer.Controllers
{
    [Authorize]
    [RoutePrefix("tests")]
    public class TestsController : ApiController
    {
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok("asdf");
        }
    }
}
