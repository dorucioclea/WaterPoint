using System.Web.Http;
using WaterPoint.Api.Common;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Contracts.JobCostItems;
using WaterPoint.Core.Domain.Payloads.Jobs;
using WaterPoint.Core.Domain.RequestParameters;
using WaterPoint.Core.Domain.Requests.JobCostItems;

namespace WaterPoint.Api.Job.Controllers
{
    [Authorize]
    [RoutePrefix(RouteDefinitions.Jobs.CostItemsPrefix)]
    public class CostItemsController : BaseOrgnizationContextController
    {
        private readonly IRequestProcessor<CreateJobCostItemRequest, CommandResultContract> _createJobCostItemRequest;
        private readonly IRequestProcessor<ListJobCostItemsRequest, PaginatedResult<JobCostItemContract>> _listJobCostItemequestProcessor;
        //private readonly IRequestProcessor<UpdateJobCostItemRequest, CommandResultContract> _updateRequestProcessor;
        //private readonly IRequestProcessor<GetJobCostItemByIdRequest, CommandResultContract> _getJobCostItemByIdProcessor;

        public CostItemsController(
            IRequestProcessor<CreateJobCostItemRequest, CommandResultContract> createJobCostItemRequest,
            IRequestProcessor<ListJobCostItemsRequest, PaginatedResult<JobCostItemContract>> listJobCostItemequestProcessor
            //IRequestProcessor<UpdateJobCostItemRequest, CommandResultContract> updateRequestProcessor,
            //IRequestProcessor<GetJobCostItemByIdRequest, CommandResultContract> getJobCostItemByIdProcessor
            )
        {
            _listJobCostItemequestProcessor = listJobCostItemequestProcessor;
            _createJobCostItemRequest = createJobCostItemRequest;
            //_updateRequestProcessor = updateRequestProcessor;
            //_getJobCostItemByIdProcessor = getJobCostItemByIdProcessor;
        }

        [Route("")]
        public IHttpActionResult Get(
            [FromUri]JobIdOrgIdRp parameter,
            [FromUri]PaginationRp pagination)
        {
            //validation
            var request = new ListJobCostItemsRequest
            {
                Parameter = parameter,
                Pagination = pagination
            };

            var result = _listJobCostItemequestProcessor.Process(request);

            return Ok(result);
        }

        //[Route("{taskId:int}")]
        //public IHttpActionResult Get([FromUri]OrgEntityRp parameter)
        //{
        //    var result = _getJobCostItemByIdProcessor.Process(
        //        new GetJobCostItemByIdRequest
        //        {
        //            Id = parameter.Id
        //        });

        //    return Ok(result);
        //}

        [Route("")]
        public IHttpActionResult Post(
            [FromUri]JobIdOrgIdRp parameter,
            [FromBody]WriteJobCostItemPayload jobCostItemPayload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _createJobCostItemRequest.Process(
                new CreateJobCostItemRequest
                {
                    Parameter = parameter,
                    Payload = jobCostItemPayload,
                    OrganizationUserId = OrganizationUser.Id
                });

            return Ok(result);
        }

        //[Route("")]
        //public IHttpActionResult Put(
        //    [FromUri] OrgEntityJobId parameter,
        //    [FromBody] Delta<WriteJobCostItemPayload> input)
        //{
        //    var jobCostItem = _updateRequestProcessor.Process(
        //        new UpdateJobCostItemRequest
        //        {
        //            Parameter = parameter,
        //            Payload = input,
        //            OrganizationUserId = OrganizationUser.Id
        //        });

        //    return Ok(jobCostItem);
        //}
    }
}
