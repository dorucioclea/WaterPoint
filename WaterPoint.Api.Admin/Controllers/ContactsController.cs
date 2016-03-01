using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Contacts;
using WaterPoint.Core.Domain.Payloads.Contacts;
using WaterPoint.Core.Domain.Requests.Contacts;

namespace WaterPoint.Api.Admin.Controllers
{
    [Authorize]
    [RoutePrefix("organizations/{organizationId:int}/contacts")]
    public class ContactsController : BaseOrgnizationContextController
    {
        private readonly IPagedProcessor<ListContactsRequest, ContactContract> _listProcessor;
        private readonly IWriteRequestProcessor<CreateContactRequest> _createProcessor;
        private readonly IRequestProcessor<GetContactRequest, ContactContract> _getContactProcessor;
        private readonly IWriteRequestProcessor<UpdateContactRequest> _updateContactProcessor;

        public ContactsController(
            IPagedProcessor<ListContactsRequest, ContactContract> listProcessor,
            IWriteRequestProcessor<CreateContactRequest> createProcessor,
            IRequestProcessor<GetContactRequest, ContactContract> getContactProcessor,
            IWriteRequestProcessor<UpdateContactRequest> updateContactProcessor)
        {
            _listProcessor = listProcessor;
            _createProcessor = createProcessor;
            _getContactProcessor = getContactProcessor;
            _updateContactProcessor = updateContactProcessor;
        }

        [Route("")]
        public IHttpActionResult Get([FromUri]ListContactsRequest request)
        {
            var result = _listProcessor.Process(request);

            return Ok(result);
        }

        [Route("")]
        public IHttpActionResult Post(
            [FromUri]CreateContactRequest request,
            [FromBody]WriteContactPayload payload)
        {
            if (!ModelState.IsValid)
                return BadRequestWithErrors(ModelState);

            request.Payload = payload;

            var result = _createProcessor.Process(request);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest();
        }

        [Route("{id:int}")]
        public IHttpActionResult Get(
            [FromUri]GetContactRequest request)
        {
            var result = _getContactProcessor.Process(request);

            return Ok(result);
        }

        [Route("{id:int}")]
        public IHttpActionResult Put(
            [FromUri]UpdateContactRequest request,
            [FromBody]Delta<WriteContactPayload> payload)
        {
            request.Payload = payload;

            var contact = _updateContactProcessor.Process(request);

            return Ok(contact);
        }
    }
}
