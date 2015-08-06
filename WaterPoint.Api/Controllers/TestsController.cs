using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WaterPoint.Api.Controllers
{
    public class TestsController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok();
        }
    }
}
