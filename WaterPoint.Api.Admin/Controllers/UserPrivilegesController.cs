using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.UserPrivileges;
using WaterPoint.Core.Domain.Payloads.UserPrivileges;
using WaterPoint.Core.Domain.Requests.UserPrivileges;

namespace WaterPoint.Api.Admin.Controllers
{
    [Authorize]
    [RoutePrefix("organizations/{organizationId:int}/users/{userId:int}/privileges")]
    public class UserPrivilegesController : BaseOrgnizationContextController
    {
        private readonly IListProcessor<ListUserPrivilegesRequest, UserPrivilegeContract> _listUserPrivilegeRequestProcessor;
        private readonly IWriteRequestProcessor<AdjustUserPrivilegeRequest> _adjustUserPrivilegeRequest;

        public UserPrivilegesController(
            IListProcessor<ListUserPrivilegesRequest, UserPrivilegeContract> listUserPrivilegeRequestProcessor,
            IWriteRequestProcessor<AdjustUserPrivilegeRequest> adjustUserPrivilegeRequest)
        {
            _listUserPrivilegeRequestProcessor = listUserPrivilegeRequestProcessor;
            _adjustUserPrivilegeRequest = adjustUserPrivilegeRequest;
        }

        [Route("")]
        public IHttpActionResult Get([FromUri]int userId)
        {
            var request = new ListUserPrivilegesRequest
            {
                OrganizationUserIds = userId.ToString()
            };

            var result = _listUserPrivilegeRequestProcessor.Process(request);

            return Ok(result);
        }

        [Route("")]
        public IHttpActionResult Post(
            [FromUri]AdjustUserPrivilegeRequest request,
            [FromBody]AdjustUserPrivilegePayload payload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestWithErrors();
            }

            request.Payload = payload;
            request.OrganizationUserId = Credential.OrganizationUserId;

            var result = _adjustUserPrivilegeRequest.Process(request);

            return Ok(result);
        }
    }
}
