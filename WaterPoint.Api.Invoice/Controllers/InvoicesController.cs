﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Invoices;
using WaterPoint.Core.Domain.Payloads.Invoices;
using WaterPoint.Core.Domain.Requests;
using WaterPoint.Core.Domain.Requests.Invoices;

namespace WaterPoint.Api.Invoice.Controllers
{
    [RoutePrefix("organizations/{organizationId:int}/invoices")]
    public class InvoicesController : BaseOrgnizationContextController
    {
        private readonly IWriteRequestProcessor<CreateInvoiceRequest> _createProcessor;
        private readonly IRequestProcessor<OrganizationEntityRequest, InvoiceContract> _getOneProcessor;
        private readonly IWriteRequestProcessor<UpdateInvoiceRequest> _updateProcessor;

        public InvoicesController(
            IWriteRequestProcessor<CreateInvoiceRequest> createProcessor,
            IRequestProcessor<OrganizationEntityRequest, InvoiceContract> getOneProcessor,
            IWriteRequestProcessor<UpdateInvoiceRequest> updateProcessor)
        {
            _createProcessor = createProcessor;
            _getOneProcessor = getOneProcessor;
            _updateProcessor = updateProcessor;
        }

        [Route("")]
        public IHttpActionResult Post(
            [FromUri]CreateInvoiceRequest request,
            [FromBody]WriteInvoicePayload payload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestWithErrors();
            }

            request.Payload = payload;

            var result = _createProcessor.Process(request);

            return Ok(result);
        }

        [Route("{id:int")]
        public IHttpActionResult Get([FromUri]OrganizationEntityRequest request)
        {
            var customer = _getOneProcessor.Process(request);

            return Ok(customer);
        }

        [Route("{id:int")]
        public IHttpActionResult Put(
            [FromUri]UpdateInvoiceRequest request,
            [FromBody]Delta<WriteInvoicePayload> payload)
        {
            request.Payload = payload;

            var customer = _updateProcessor.Process(request);

            return Ok(customer);
        }
    }
}
