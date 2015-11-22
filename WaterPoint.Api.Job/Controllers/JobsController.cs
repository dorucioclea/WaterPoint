using System.Collections.Generic;
using System.Web.Http;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Jobs;
using WaterPoint.Core.Domain.Dtos;
using WaterPoint.Core.Domain.Dtos.Shared.Requests;

namespace WaterPoint.Api.Job.Controllers
{
    public class JobsController : ApiController
    {
        private readonly IRequestProcessor<PaginationWithOrgIdRequest, PaginatedResult<IEnumerable<JobContract>>> _listCustomeRequestProcessor;

        public JobsController(
            IRequestProcessor<PaginationWithOrgIdRequest, PaginatedResult<IEnumerable<JobContract>>> listCustomeRequestProcessor)
        {
            _listCustomeRequestProcessor = listCustomeRequestProcessor;
        }

        [Route("")]
        public IHttpActionResult Get(
            [FromUri]OrganizationIdParameter parameter,
            [FromUri]PaginationParamter pagination)
        {
            //validation
            var request = new PaginationWithOrgIdRequest
            {
                OrganizationIdParameter = parameter,
                PaginationParamter = pagination
            };

            var result = _listCustomeRequestProcessor.Process(request);

            return Ok(result);
        }
    }
}
