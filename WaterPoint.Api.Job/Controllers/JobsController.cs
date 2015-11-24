using System.Collections.Generic;
using System.Web.Http;
using WaterPoint.Api.Common;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Jobs;
using WaterPoint.Core.Domain.Dtos;
using WaterPoint.Core.Domain.Dtos.Requests.Jobs;
using WaterPoint.Core.Domain.Dtos.Requests.Shared;

namespace WaterPoint.Api.Job.Controllers
{
    [RoutePrefix(RouteDefinitions.Jobs.Prefix)]
    public class JobsController : ApiController
    {
        private readonly IRequestProcessor<PaginationWithOrgIdRequest, PaginatedResult<IEnumerable<JobContract>>> _listCustomeRequestProcessor;
        private readonly IRequestProcessor<GetJobByIdRequest, JobContract> _getJobByIdRequestProcessor;

        public JobsController(
            IRequestProcessor<PaginationWithOrgIdRequest, PaginatedResult<IEnumerable<JobContract>>> listCustomeRequestProcessor,
            IRequestProcessor<GetJobByIdRequest, JobContract> getJobByIdRequestProcessor)
        {
            _listCustomeRequestProcessor = listCustomeRequestProcessor;
            _getJobByIdRequestProcessor = getJobByIdRequestProcessor;
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

        [Route("{id:int}")]
        public IHttpActionResult Get([FromUri]OrganizationEntityParameter parameter)
        {
            var result = _getJobByIdRequestProcessor.Process(
                new GetJobByIdRequest
                {
                    OrganizationEntityParameter = parameter
                });

            return Ok(result);
        }
    }
}
