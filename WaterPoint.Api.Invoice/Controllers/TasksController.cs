using System.Web.Http;
using System.Web.Http.OData;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.InvoiceTasks;
using WaterPoint.Core.Domain.Payloads.InvoiceTasks;
using WaterPoint.Core.Domain.Requests.InvoiceTasks;

namespace WaterPoint.Api.Invoice.Controllers
{
    [RoutePrefix("organizations/{organizationId:int}")]
    public class TasksController : BaseOrgnizationContextController
    {
        private readonly IWriteRequestProcessor<CreateInvoiceTaskRequest> _createProcessor;
        private readonly ISimplePagedProcessor<ListInvoiceTasksRequest, InvoiceTaskBasicContract> _listProcessor;
        private readonly IRequestProcessor<GetInvoiceTaskRequest, InvoiceTaskContract> _getProcessor;
        private readonly IWriteRequestProcessor<UpdateInvoiceTaskRequest> _updateProcessor;

        public TasksController(
            IWriteRequestProcessor<CreateInvoiceTaskRequest> createProcessor,
            ISimplePagedProcessor<ListInvoiceTasksRequest, InvoiceTaskBasicContract> listProcessor,
            IRequestProcessor<GetInvoiceTaskRequest, InvoiceTaskContract> getProcessor,
            IWriteRequestProcessor<UpdateInvoiceTaskRequest> updateProcessor)
        {
            _createProcessor = createProcessor;
            _listProcessor = listProcessor;
            _getProcessor = getProcessor;
            _updateProcessor = updateProcessor;
        }

        [Route("quotes/{quoteId:int}/tasks")]
        public IHttpActionResult Post(
            [FromUri]CreateInvoiceTaskRequest request,
            [FromBody]CreateInvoiceTaskPayload payload)
        {
            if (!ModelState.IsValid)
                return BadRequestWithErrors();

            request.Payload = payload;

            var result = _createProcessor.Process(request);

            return Ok(result);
        }

        [Route("quotes/{quoteId:int}/tasks")]
        public IHttpActionResult Get([FromUri]ListInvoiceTasksRequest request)
        {
            var result = _listProcessor.Process(request);

            return Ok(result);
        }

        [Route("quotes/{quoteId:int}/tasks/{id:int}")]
        public IHttpActionResult Get([FromUri]GetInvoiceTaskRequest request)
        {
            var result = _getProcessor.Process(request);

            return Ok(result);
        }


        [Route("quotes/{quoteId:int}/tasks/{id:int}")]
        public IHttpActionResult Put(
            [FromUri]UpdateInvoiceTaskRequest request,
            [FromBody]Delta<UpdateInvoiceTaskPayload> payload)
        {
            if (!ModelState.IsValid)
                return BadRequestWithErrors();

            request.Payload = payload;

            var result = _updateProcessor.Process(request);

            return Ok(result);
        }
    }
}
