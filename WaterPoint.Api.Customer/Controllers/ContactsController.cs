using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Contacts;
using WaterPoint.Core.Domain.Requests.Contacts;

namespace WaterPoint.Api.Customer.Controllers
{
    [Authorize]
    [RoutePrefix("organizations/{organizationId:int}/customers/{customerId:int}")]
    public class ContactsController : BaseOrgnizationContextController
    {
        private readonly IListProcessor<ListContactsForCustomerRequest, ContactContract> _listProcessor;

        public ContactsController(
            IListProcessor<ListContactsForCustomerRequest, ContactContract> listProcessor)
        {
            _listProcessor = listProcessor;
        }

        [Route("")]
        public IHttpActionResult Get([FromUri]ListContactsForCustomerRequest request)
        {
            var result = _listProcessor.Process(request);

            return Ok(result);
        }
    }
}
