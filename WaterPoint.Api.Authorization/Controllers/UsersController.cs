using System.Web.Http;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Payloads.OrganizationUsers;
using WaterPoint.Core.Domain.Requests.OrganizationUsers;

namespace WaterPoint.Api.Authorization.Controllers
{
    [Authorize]
    [RoutePrefix("organizations/{organizationId:int}/users")]
    public class UsersController : BaseOrgnizationContextController
    {
        private readonly IWriteRequestProcessor<EnterOrganizationRequest> _signinRequestProcessor;

        public UsersController(
            IWriteRequestProcessor<EnterOrganizationRequest> signinRequestProcessor)
        {
            _signinRequestProcessor = signinRequestProcessor;
        }

        [Route("{id:int}/entrance")]
        [HttpPost]
        public IHttpActionResult SelectOrganization([FromUri]EnterOrganizationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestWithErrors();
            }

            request.Payload = new SignInManagementPayload { ToSignIn = true };

            var result = _signinRequestProcessor.Process(request);

            return Ok(result);
        }

        [Route("{id:int}/entrance")]
        [HttpDelete]
        public IHttpActionResult UnselectOrganization([FromUri]EnterOrganizationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestWithErrors();
            }

            request.Payload = new SignInManagementPayload { ToSignIn = false };

            var result = _signinRequestProcessor.Process(request);

            return Ok(result);
        }
    }
}
