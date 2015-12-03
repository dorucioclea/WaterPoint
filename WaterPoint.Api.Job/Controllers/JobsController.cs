using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.OData;
using WaterPoint.Api.Common;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Jobs;
using WaterPoint.Core.Domain.Dtos;
using WaterPoint.Core.Domain.Dtos.Payloads.Jobs;
using WaterPoint.Core.Domain.Dtos.Requests.Jobs;
using WaterPoint.Core.Domain.Dtos.Requests.Shared;

namespace WaterPoint.Api.Job.Controllers
{
    [RoutePrefix(RouteDefinitions.Jobs.Prefix)]
    public class JobsController : BaseOrgnizationContextController
    {
        private readonly IRequestProcessor<PaginationWithOrgIdRequest, PaginatedResult<IEnumerable<JobContract>>> _listJobRequestProcessor;
        private readonly IRequestProcessor<GetJobByIdRequest, JobContract> _getJobByIdRequestProcessor;
        private readonly IRequestProcessor<CreateJobRequest, JobContract> _createJobRequestProcessor;
        private readonly IRequestProcessor<UpdateJobRequest, JobContract> _updateJobRequestProcessor;

        public JobsController(
            IRequestProcessor<PaginationWithOrgIdRequest, PaginatedResult<IEnumerable<JobContract>>> listJobRequestProcessor,
            IRequestProcessor<GetJobByIdRequest, JobContract> getJobByIdRequestProcessor,
            IRequestProcessor<CreateJobRequest, JobContract> createJobRequestProcessor,
            IRequestProcessor<UpdateJobRequest, JobContract> updateJobRequestProcessor)
        {
            _listJobRequestProcessor = listJobRequestProcessor;
            _getJobByIdRequestProcessor = getJobByIdRequestProcessor;
            _createJobRequestProcessor = createJobRequestProcessor;
            _updateJobRequestProcessor = updateJobRequestProcessor;
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

            var result = _listJobRequestProcessor.Process(request);

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


        [Route("")]
        public IHttpActionResult Post(
            [FromUri]OrganizationIdParameter parameter,
            [FromBody]WriteJobPayload jobPayload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = _createJobRequestProcessor.Process(
                new CreateJobRequest
                {
                    OrganizationIdParameter = parameter,
                    CreateJobPayload = jobPayload,
                    StaffId = Staff.Id
                });

            return Ok(result);
        }

        [Route("{id:int}")]
        public IHttpActionResult Put(
            [FromUri] OrganizationEntityParameter parameter,
            [FromBody] Delta<WriteJobPayload> input)
        {
            var job = _updateJobRequestProcessor.Process(
                new UpdateJobRequest
                {
                    OrganizationEntityParameter = parameter,
                    UpdateJobPayload = input,
                    StaffId = Staff.Id
                });

            return Ok(job);
        }
    }
}
