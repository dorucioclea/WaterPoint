using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.OData;
using WaterPoint.Api.Common;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Jobs;
using WaterPoint.Core.Domain.Dtos;
using WaterPoint.Core.Domain.Dtos.RequestParameters;
using WaterPoint.Core.Domain.Dtos.Payloads.Jobs;
using WaterPoint.Core.Domain.Dtos.Requests.Jobs;
using WaterPoint.Core.Domain.Dtos.Requests.Shared;

namespace WaterPoint.Api.Job.Controllers
{
    [Authorize]
    [RoutePrefix(RouteDefinitions.Jobs.Prefix)]
    public class JobsController : BaseOrgnizationContextController
    {
        private readonly IRequestProcessor<ListJobsRequest, PaginatedResult<JobWithCustomerContract>> _listJobRequestProcessor;
        private readonly IRequestProcessor<GetJobByIdRequest, JobWithDetailsContract> _getJobByIdRequestProcessor;
        private readonly IRequestProcessor<CreateJobRequest, JobWithDetailsContract> _createJobRequestProcessor;
        //private readonly IRequestProcessor<UpdateJobRequest, JobContract> _updateJobRequestProcessor;

        public JobsController(
            IRequestProcessor<ListJobsRequest, PaginatedResult<JobWithCustomerContract>> listJobRequestProcessor,
            IRequestProcessor<GetJobByIdRequest, JobWithDetailsContract> getJobByIdRequestProcessor,
            IRequestProcessor<CreateJobRequest, JobWithDetailsContract> createJobRequestProcessor
            //IRequestProcessor<UpdateJobRequest, JobContract> updateJobRequestProcessor
            )
        {
            _listJobRequestProcessor = listJobRequestProcessor;
            _getJobByIdRequestProcessor = getJobByIdRequestProcessor;
            _createJobRequestProcessor = createJobRequestProcessor;
            //_updateJobRequestProcessor = updateJobRequestProcessor;
        }

        [Route("")]
        public IHttpActionResult Get(
            [FromUri]OrgIdRp parameter,
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
                OrganizationIdParameter = parameter,
                PaginationParamter = pagination,
                JobStatusParameter = jobStatusParamter
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
            [FromBody]WriteBasicJobDataPayload jobPayload)
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

        //[Route("{id:int}")]
        //public IHttpActionResult Put(
        //    [FromUri] OrganizationEntityParameter parameter,
        //    [FromBody] Delta<WriteJobPayload> input)
        //{
        //    var job = _updateJobRequestProcessor.Process(
        //        new UpdateJobRequest
        //        {
        //            OrganizationEntityParameter = parameter,
        //            UpdateJobPayload = input,
        //            OrganizationUserId = OrganizationUser.Id
        //        });

        //    return Ok(job);
        //}
    }
}
