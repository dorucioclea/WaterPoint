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
        private readonly IPagedProcessor<ListJobsRequest, JobWithCustomerContract> _listJobRequestProcessor;
        private readonly IRequestProcessor<GetJobByIdRequest, JobDetailsContract> _getJobByIdRequestProcessor;
        private readonly IWriteRequestProcessor<CreateJobRequest> _createJobRequestProcessor;
        private readonly IWriteRequestProcessor<UpdateJobRequest> _updateJobRequestProcessor;

        public JobsController(
            IPagedProcessor<ListJobsRequest, JobWithCustomerContract> listJobRequestProcessor,
            IRequestProcessor<GetJobByIdRequest, JobDetailsContract> getJobByIdRequestProcessor,
            IWriteRequestProcessor<CreateJobRequest> createJobRequestProcessor,
            IWriteRequestProcessor<UpdateJobRequest> updateJobRequestProcessor
            )
        {
            _listJobRequestProcessor = listJobRequestProcessor;
            _getJobByIdRequestProcessor = getJobByIdRequestProcessor;
            _createJobRequestProcessor = createJobRequestProcessor;
            _updateJobRequestProcessor = updateJobRequestProcessor;
        }

        [Route("")]
        public IHttpActionResult Get([FromUri]ListJobsRequest request)
        {
            var result = _listJobRequestProcessor.Process(request);

            return Ok(result);
        }

        [Route("{id:int}")]
        public IHttpActionResult Get([FromUri]GetJobByIdRequest request)
        {
            var result = _getJobByIdRequestProcessor.Process(request);

            return Ok(result);
        }


        [Route("")]
        public IHttpActionResult Post(
            [FromUri]CreateJobRequest request,
            [FromBody]WriteJobPayload jobPayload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestWithErrors(ModelState);
            }

            request.Payload = jobPayload;
            request.OrganizationUserId = Credential.Id;

            var result = _createJobRequestProcessor.Process(request);

            return Ok(result);
        }

        [Route("{id:int}")]
        public IHttpActionResult Put(
            [FromUri]UpdateJobRequest request,
            [FromBody]Delta<WriteJobPayload> input)
        {
            request.OrganizationUserId = Credential.Id;
            request.Payload = input;

            var job = _updateJobRequestProcessor.Process(request);

            return Ok(job);
        }
    }
}
