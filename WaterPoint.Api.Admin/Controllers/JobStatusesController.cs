using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.JobStatuses;
using WaterPoint.Core.Domain.Requests;

namespace WaterPoint.Api.Admin.Controllers
{
    [Authorize]
    [RoutePrefix("organizations/{organizationId:int}/jobstatuses")]
    public class JobStatusesController : BaseOrgnizationContextController
    {
        private readonly IListProcessor<ListOrgEntitiesRequest, JobStatusContract> _listProcessor;

        public JobStatusesController(
            IListProcessor<ListOrgEntitiesRequest, JobStatusContract> listProcessor)
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
