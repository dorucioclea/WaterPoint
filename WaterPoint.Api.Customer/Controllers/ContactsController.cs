using System.Web.Http;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Contacts;
using WaterPoint.Core.Domain.Payloads.Contacts;
using WaterPoint.Core.Domain.Requests.Contacts;

namespace WaterPoint.Api.Customer.Controllers
{
    [Authorize]
    [RoutePrefix("organizations/{organizationId:int}")]
    public class ContactsController : BaseOrgnizationContextController
    {
        private readonly IListProcessor<ListCustomerContactsRequest, CustomerContactContract> _listProcessor;
        private readonly IWriteRequestProcessor<CreateCustomerContactRequest> _createProcessor;

        public ContactsController(
            IListProcessor<ListCustomerContactsRequest, CustomerContactContract> listProcessor,
            IWriteRequestProcessor<CreateCustomerContactRequest> createProcessor)
        {
            _listProcessor = listProcessor;
            _createProcessor = createProcessor;
        }

        [Route("customers/{customerId:int}/contacts")]
        public IHttpActionResult Get([FromUri]ListCustomerContactsRequest request)
        {
            var result = _listProcessor.Process(request);

            return Ok(result);
        }

        [Route("customers/{customerId:int}/contacts")]
        public IHttpActionResult Post(
            [FromUri]CreateCustomerContactRequest request,
            [FromBody]WriteCustomerContactPayload payload)
        {
            if (!ModelState.IsValid)
                return BadRequestWithErrors();

            request.Payload = payload;

            var result = _createProcessor.Process(request);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest();
        }
    }
}
