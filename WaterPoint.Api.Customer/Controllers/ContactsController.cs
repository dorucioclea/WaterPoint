using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Contacts;
using WaterPoint.Core.Domain.Payloads.Contacts;
using WaterPoint.Core.Domain.Requests.Contacts;

namespace WaterPoint.Api.Customer.Controllers
{
    [Authorize]
    [RoutePrefix("organizations/{organizationId:int}/customers/{customerId:int}/contacts")]
    public class ContactsController : BaseOrgnizationContextController
    {
        private readonly IListProcessor<ListContactsForCustomerRequest, ContactContract> _listProcessor;
        private readonly IWriteRequestProcessor<CreateContactForCustomerRequest> _createProcessor;

        public ContactsController(
            IListProcessor<ListContactsForCustomerRequest, ContactContract> listProcessor,
            IWriteRequestProcessor<CreateContactForCustomerRequest> createProcessor)
        {
            _listProcessor = listProcessor;
            _createProcessor = createProcessor;
        }

        [Route("")]
        public IHttpActionResult Get([FromUri]ListContactsForCustomerRequest request)
        {
            var result = _listProcessor.Process(request);

            return Ok(result);
        }

        [Route("")]
        public IHttpActionResult Post(
            [FromUri]CreateContactForCustomerRequest request,
            [FromBody]CreateContactPayload payload)
        {
            if (!ModelState.IsValid)
                return BadRequestWithErrors(ModelState);

            request.Payload = payload;

            var result = _createProcessor.Process(request);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest();
        }
    }
}
