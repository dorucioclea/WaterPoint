﻿using System.Web.Http;
using System.Web.Http.OData;
using Ninject;
using WaterPoint.Api.Common;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Contracts.JobTimesheet;
using WaterPoint.Core.Domain.Payloads.JobTimesheet;
using WaterPoint.Core.Domain.RequestParameters;
using WaterPoint.Core.Domain.Requests;
using WaterPoint.Core.Domain.Requests.JobTimesheet;

namespace WaterPoint.Api.Job.Controllers
{
    [Authorize]
    [RoutePrefix(RouteDefinitions.Jobs.JobTimesheetPrefix)]
    public class JobTimesheetController : BaseOrgnizationContextController
    {
        private readonly IWriteRequestProcessor<CreateJobTimesheetRequest> _createRequestProcessor;
        private readonly IListProcessor<ListJobTimesheetRequest, JobTimesheetBasicContract> _listoRequestProcessor;
        private readonly IRequestProcessor<GetJobTimesheetRequest, JobTimesheetContract> _getRequestProcessor;
        private readonly IWriteRequestProcessor<UpdateJobTimesheetRequest> _updateRequestProcessor;
        private readonly IDeleteRequestProcessor<OrganizationEntityRequest> _deleteProcessor;

        public JobTimesheetController(
            IWriteRequestProcessor<CreateJobTimesheetRequest> createRequestProcessor,
            IListProcessor<ListJobTimesheetRequest, JobTimesheetBasicContract> listoRequestProcessor,
            IRequestProcessor<GetJobTimesheetRequest, JobTimesheetContract> getRequestProcessor,
            IWriteRequestProcessor<UpdateJobTimesheetRequest> updateRequestProcessor,
            [Named("DeleteJobTimesheet")]
            IDeleteRequestProcessor<OrganizationEntityRequest> deleteProcessor)
        {
            _createRequestProcessor = createRequestProcessor;
            _listoRequestProcessor = listoRequestProcessor;
            _getRequestProcessor = getRequestProcessor;
            _updateRequestProcessor = updateRequestProcessor;
            _deleteProcessor = deleteProcessor;
        }

        [Route("")]
        public IHttpActionResult Get(
            [FromUri]ListJobTimesheetRequest request)
        {
            var result = _listoRequestProcessor.Process(request);

            return Ok(result);
        }

        [Route("")]
        public IHttpActionResult Post(
            [FromUri]CreateJobTimesheetRequest request,
            [FromBody]WriteJobTimesheetPayload payload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestWithErrors();
            }

            //TODO: validator
            //TODO: staff privilege (admin can create timesheet for others, but others can only create for themselves)
            request.Payload = payload;

            var result = _createRequestProcessor.Process(request);

            return Ok(result);
        }

        [Route("{id:int}")]
        public IHttpActionResult Get([FromUri]GetJobTimesheetRequest request)
        {
            var result = _getRequestProcessor.Process(request);

            return Ok(result);
        }

        [Route("{id:int}")]
        public IHttpActionResult Put(
            [FromUri]UpdateJobTimesheetRequest request,
            [FromBody]Delta<WriteJobTimesheetPayload> payload)
        {
            request.Payload = payload;

            var result = _updateRequestProcessor.Process(request);

            return Ok(result);
        }

        [Route("{id:int}")]
        public IHttpActionResult Delete([FromUri]OrganizationEntityRequest request)
        {
            var result = _deleteProcessor.Process(request);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest();
        }
    }
}
