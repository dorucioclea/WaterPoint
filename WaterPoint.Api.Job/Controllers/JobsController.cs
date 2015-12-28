using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.OData;
using WaterPoint.Api.Common;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Contracts.Jobs;

using WaterPoint.Core.Domain.RequestParameters;
using WaterPoint.Core.Domain.Payloads.Jobs;
using WaterPoint.Core.Domain.Requests.Jobs;
using WaterPoint.Core.Domain.Requests.Shared;

namespace WaterPoint.Api.Job.Controllers
{
    [Authorize]
    [RoutePrefix(RouteDefinitions.Jobs.Prefix)]
    public class JobsController : BaseOrgnizationContextController
    {
        private readonly IRequestProcessor<ListJobsRequest, PaginatedResult<JobWithCustomerContract>> _listJobRequestProcessor;
        private readonly IRequestProcessor<GetJobByIdRequest, JobDetailsContract> _getJobByIdRequestProcessor;
        private readonly IRequestProcessor<CreateJobRequest, CommandResultContract> _createJobRequestProcessor;
        private readonly IRequestProcessor<UpdateJobRequest, CommandResultContract> _updateJobRequestProcessor;

        public JobsController(
            IRequestProcessor<ListJobsRequest, PaginatedResult<JobWithCustomerContract>> listJobRequestProcessor,
            IRequestProcessor<GetJobByIdRequest, JobDetailsContract> getJobByIdRequestProcessor,
            IRequestProcessor<CreateJobRequest, CommandResultContract> createJobRequestProcessor,
            IRequestProcessor<UpdateJobRequest, CommandResultContract> updateJobRequestProcessor
            )
        {
            _listJobRequestProcessor = listJobRequestProcessor;
            _getJobByIdRequestProcessor = getJobByIdRequestProcessor;
            _createJobRequestProcessor = createJobRequestProcessor;
            _updateJobRequestProcessor = updateJobRequestProcessor;
        }

        [Route("")]
        public IHttpActionResult Get(
            [FromUri]PaginationRp pagination,
            [FromUri]JobStatusRp jobStatusParamter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            //validation
            var request = new ListJobsRequest
            {
                Pagination = pagination,
                Parameter = jobStatusParamter
            };

            var result = _listJobRequestProcessor.Process(request);

            return Ok(result);
        }

        [Route("{id:int}")]
        public IHttpActionResult Get([FromUri]OrgEntityRp parameter)
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
            [FromUri]OrgIdRp parameter,
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
                    OrganizationUserId = OrganizationUser.Id
                });

            return Ok(result);
        }

        [Route("{id:int}")]
        public IHttpActionResult Put(
            [FromUri] OrgEntityRp parameter,
            [FromBody] Delta<WriteJobPayload> input)
        {
            var job = _updateJobRequestProcessor.Process(
                new UpdateJobRequest
                {
                    Parameter = parameter,
                    Payload = input,
                    OrganizationUserId = OrganizationUser.Id
                });

            return Ok(job);
        }
    }
}
