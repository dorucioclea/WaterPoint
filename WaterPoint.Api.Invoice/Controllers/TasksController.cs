using System.Web.Http;
using System.Web.Http.OData;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.InvoiceJobTasks;
using WaterPoint.Core.Domain.Payloads.InvoiceJobTasks;
using WaterPoint.Core.Domain.Requests.InvoiceJobTasks;

namespace WaterPoint.Api.Invoice.Controllers
{
    [RoutePrefix("organizations/{organizationId:int}")]
    public class TasksController : BaseOrgnizationContextController
    {
        private readonly IWriteRequestProcessor<CreateInvoiceJobTaskRequest> _createProcessor;
        private readonly ISimplePagedProcessor<ListInvoiceJobTasksRequest, InvoiceJobTaskBasicContract> _listProcessor;
        private readonly IRequestProcessor<GetInvoiceJobTaskRequest, InvoiceJobTaskContract> _getProcessor;
        private readonly IWriteRequestProcessor<UpdateInvoiceJobTaskRequest> _updateProcessor;

        public TasksController(
            IWriteRequestProcessor<CreateInvoiceJobTaskRequest> createProcessor,
            ISimplePagedProcessor<ListInvoiceJobTasksRequest, InvoiceJobTaskBasicContract> listProcessor,
            IRequestProcessor<GetInvoiceJobTaskRequest, InvoiceJobTaskContract> getProcessor,
            IWriteRequestProcessor<UpdateInvoiceJobTaskRequest> updateProcessor)
        {
            _createProcessor = createProcessor;
            _listProcessor = listProcessor;
            _getProcessor = getProcessor;
            _updateProcessor = updateProcessor;
        }

        [Route("quotes/{quoteId:int}/tasks")]
        public IHttpActionResult Post(
            [FromUri]CreateInvoiceJobTaskRequest request,
            [FromBody]CreateInvoiceJobTaskPayload payload)
        {
            if (!ModelState.IsValid)
                return BadRequestWithErrors(ModelState);

            request.Payload = payload;

            var result = _createProcessor.Process(request);

            return Ok(result);
        }

        [Route("quotes/{quoteId:int}/tasks")]
        public IHttpActionResult Get([FromUri]ListInvoiceJobTasksRequest request)
        {
            var result = _listProcessor.Process(request);

            return Ok(result);
        }

        [Route("quotes/{quoteId:int}/tasks/{id:int}")]
        public IHttpActionResult Get([FromUri]GetInvoiceJobTaskRequest request)
        {
            var result = _getProcessor.Process(request);

            return Ok(result);
        }


        [Route("quotes/{quoteId:int}/tasks/{id:int}")]
        public IHttpActionResult Put(
            [FromUri]UpdateInvoiceJobTaskRequest request,
            [FromBody]Delta<UpdateInvoiceJobTaskPayload> payload)
        {
            if (!ModelState.IsValid)
                return BadRequestWithErrors(ModelState);

            request.Payload = payload;

            var result = _updateProcessor.Process(request);

            return Ok(result);
        }
    }
}
