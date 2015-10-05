using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WaterPoint.Api.Common;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Requests.Products;
using WaterPoint.Core.RequestProcessor.Contracts.Products;

namespace WaterPoint.Api.Flag.Controllers
{
    [RoutePrefix(RouteDefinitions.Flags.Prefix)]
    public class FlagsController : BaseOrgnizationContextController
    {
        private readonly IRequestProcessor<ListProductsByFlagRequest, IEnumerable<BasicProduct>> _listProductsByFlagProcessor;

        public FlagsController(
            IRequestProcessor<ListProductsByFlagRequest, IEnumerable<BasicProduct>> listProductsByFlagProcessor)
        {
            _listProductsByFlagProcessor = listProductsByFlagProcessor;
        }

        [Route(RouteDefinitions.Flags.GetProducts)]
        public IHttpActionResult GetProducts([FromUri]ListProductsByFlagRequest request)
        {
            //validation

            var result = _listProductsByFlagProcessor.Process(request);

            return Ok(result);
        }
    }
}
