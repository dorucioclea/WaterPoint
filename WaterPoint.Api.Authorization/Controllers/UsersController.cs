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
        private readonly IWriteRequestProcessor<SignInManagementRequest> _signinRequestProcessor;

        public UsersController(
            IWriteRequestProcessor<SignInManagementRequest> signinRequestProcessor)
        {
            _signinRequestProcessor = signinRequestProcessor;
        }

        [Route("{id:int}/signin")]
        [HttpPost]
        public IHttpActionResult SignIn(
            [FromUri]SignInManagementRequest request,
            [FromBody]SignInManagementPayload payload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestWithErrors(ModelState);
            }

            request.Payload = payload;

            var result = _signinRequestProcessor.Process(request);

            return Ok(result);
        }
    }
}
