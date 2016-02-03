using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Staff;
//using WaterPoint.Core.Domain.Payloads.Staff;
using WaterPoint.Core.Domain.Requests.Staff;

namespace WaterPoint.Api.Authorization.Controllers
{
    [Authorize]
    [RoutePrefix("organizations/{organizationId:int}/staff")]
    public class StaffController : BaseOrgnizationContextController
    {
        private readonly IListProcessor<ListStaffRequest, StaffContract> _listStaffRequestProcessor;
        private readonly IRequestProcessor<GetStaffRequest, StaffContract> _getStaffProcessor;

        public StaffController(
            IListProcessor<ListStaffRequest, StaffContract> listStaffRequestProcessor,
            IRequestProcessor<GetStaffRequest, StaffContract> getStaffProcessor)
        {
            _listStaffRequestProcessor = listStaffRequestProcessor;
            _getStaffProcessor = getStaffProcessor;
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

        //[Route("")]
        //public IHttpActionResult Post(
        //    [FromUri]AdjustStaffRequest request,
        //    [FromBody]AdjustStaffPayload payload)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequestWithErrors(ModelState);
        //    }

        //    request.Payload = payload;
        //    request.OrganizationUserId = Credential.OrganizationUserId;

        //    var result = _adjustStaffRequest.Process(request);

        //    return Ok(result);
        //}
    }
}
