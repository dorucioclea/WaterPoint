using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Staff;
using WaterPoint.Core.Domain.Payloads.StaffPayloads;
//using WaterPoint.Core.Domain.Payloads.Staff;
using WaterPoint.Core.Domain.Requests.Staff;

namespace WaterPoint.Api.Admin.Controllers
{
    [Authorize]
    [RoutePrefix("organizations/{organizationId:int}/staff")]
    public class StaffController : BaseOrgnizationContextController
    {
        private readonly ISimplePagedProcessor<ListStaffRequest, BasicStaffContract> _listStaffRequestProcessor;
        private readonly IRequestProcessor<GetStaffRequest, StaffContract> _getStaffProcessor;
        private readonly IWriteRequestProcessor<CreateStaffRequest> _createStaffProcessor;

        public StaffController(
            ISimplePagedProcessor<ListStaffRequest, BasicStaffContract> listStaffRequestProcessor,
            IRequestProcessor<GetStaffRequest, StaffContract> getStaffProcessor,
            IWriteRequestProcessor<CreateStaffRequest> createStaffProcessor)
        {
            _listStaffRequestProcessor = listStaffRequestProcessor;
            _getStaffProcessor = getStaffProcessor;
            _createStaffProcessor = createStaffProcessor;
        }

        [Route("")]
        public IHttpActionResult Get([FromUri]ListStaffRequest request)
        {
            var result = _listStaffRequestProcessor.Process(request);

            return Ok(result);
        }

        [Route("{id:int}")]
        public IHttpActionResult Get([FromUri]GetStaffRequest request)
        {
            var result = _getStaffProcessor.Process(request);

            return Ok(result);
        }

        [Route("")]
        public IHttpActionResult Post(
           [FromUri]CreateStaffRequest request,
           [FromBody]CreateStaffPayload payload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestWithErrors(ModelState);
            }

            request.Payload = payload;

            var result = _createStaffProcessor.Process(request);

            return Ok(result);
        }
    }
}
