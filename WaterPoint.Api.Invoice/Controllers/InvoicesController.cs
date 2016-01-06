using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Payloads.Invoices;
using WaterPoint.Core.Domain.Requests.Invoices;

namespace WaterPoint.Api.Invoice.Controllers
{
    [RoutePrefix("organizations/{organizationId:int}/customers/{customerId:int}/invoices")]
    public class InvoicesController : BaseOrgnizationContextController
    {
        private readonly IWriteRequestProcessor<CreateInvoiceRequest> _createProcessor;

        public InvoicesController(
            IWriteRequestProcessor<CreateInvoiceRequest> createProcessor)
        {
            _createProcessor = createProcessor;
        }

        [Route("")]
        public IHttpActionResult Post(
            [FromUri]CreateInvoiceRequest request,
            [FromBody]CreateInvoicePayload payload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestWithErrors(ModelState);
            }

            request.Payload = payload;

            var result = _createProcessor.Process(request);

            return Ok(result);
        }
    }
}
