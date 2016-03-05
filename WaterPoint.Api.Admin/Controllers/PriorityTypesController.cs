using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Jobs;
using WaterPoint.Core.Domain.Payloads.Addresses;
using WaterPoint.Core.Domain.Requests;
using WaterPoint.Core.Domain.Requests.Addresses;

namespace WaterPoint.Api.Admin.Controllers
{
    [Authorize]
    [RoutePrefix("organizations/{organizationId:int}/prioritytypes")]
    public class PriorityTypesController : BaseOrgnizationContextController
    {
        private readonly IListProcessor<ListOrgEntitiesRequest, PriorityTypeContract> _listProcessor;

        public PriorityTypesController(
            IListProcessor<ListOrgEntitiesRequest, PriorityTypeContract> listProcessor)
        {
            _listProcessor = listProcessor;
        }

        [Route("")]
        public IHttpActionResult Get([FromUri]ListOrgEntitiesRequest request)
        {
            var result = _listProcessor.Process(request);

            return Ok(result);
        }
    }
}
