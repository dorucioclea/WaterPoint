using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.OData;
using WaterPoint.Api.Common;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Customers;

using WaterPoint.Core.Domain.Payloads.Customers;
using WaterPoint.Core.Domain.Requests;
using WaterPoint.Core.Domain.Requests.Customers;

namespace WaterPoint.Api.Customer.Controllers
{
    [Authorize]
    [RoutePrefix("organizations/{organizationId:int}/customers")]
    public class CustomersController : BaseOrgnizationContextController
    {
        private readonly IListProcessor<SearchTermRequest, CustomerContract> _searchTop10Processor;
        private readonly IPagedProcessor<ListCustomersRequest, CustomerContract> _listCustomerRequestProcessor;
        private readonly IWriteRequestProcessor<CreateCustomerRequest> _createCustomerRequest;
        private readonly IWriteRequestProcessor<UpdateCustomerRequest> _updateRequestProcessor;
        private readonly IRequestProcessor<GetCustomerRequest, CustomerContract> _getCustomerByIdProcessor;
        private readonly IDeleteRequestProcessor<OrganizationEntityRequest> _deleteRequestProcessor;
        private readonly IDeleteRequestProcessor<BulkDeleteCustomersRequest> _bulkDeleteRequestProcessor;

        public CustomersController(
            IListProcessor<SearchTermRequest, CustomerContract> searchTop10Processor,
            IPagedProcessor<ListCustomersRequest, CustomerContract> listCustomerRequestProcessor,
            IWriteRequestProcessor<CreateCustomerRequest> createCustomerRequest,
            IWriteRequestProcessor<UpdateCustomerRequest> updateRequestProcessor,
            IRequestProcessor<GetCustomerRequest, CustomerContract> getCustomerByIdProcessor,
            IDeleteRequestProcessor<OrganizationEntityRequest> deleteRequestProcessor,
            IDeleteRequestProcessor<BulkDeleteCustomersRequest> bulkDeleteRequestProcessor
            )
        {
            _searchTop10Processor = searchTop10Processor;
            _listCustomerRequestProcessor = listCustomerRequestProcessor;
            _createCustomerRequest = createCustomerRequest;
            _updateRequestProcessor = updateRequestProcessor;
            _getCustomerByIdProcessor = getCustomerByIdProcessor;
            _deleteRequestProcessor = deleteRequestProcessor;
            _bulkDeleteRequestProcessor = bulkDeleteRequestProcessor;
        }

        [Route("names")]
        public IHttpActionResult Get([FromUri]SearchTermRequest request)
        {
            var searchTerm = SearchTermHelper.ConvertToSearchTerm(request.SearchTerm);

            if (string.IsNullOrWhiteSpace(searchTerm))
                throw new InvalidOperationException("invalid search term");

            request.SearchTerm = searchTerm;

            var result = _searchTop10Processor.Process(request);

            return Ok(result);
        }

        [Route("")]
        public IHttpActionResult Get([FromUri]ListCustomersRequest request)
        {
            var result = _listCustomerRequestProcessor.Process(request);

            return Ok(result);
        }

        [Route("{id:int}")]
        public IHttpActionResult Get([FromUri]GetCustomerRequest request)
        {
            var result = _getCustomerByIdProcessor.Process(request);

            return Ok(result);
        }

        [Route("")]
        public IHttpActionResult Post(
            [FromUri]CreateCustomerRequest request,
            [FromBody]WriteCustomerPayload payload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestWithErrors();
            }

            request.Payload = payload;
            request.OrganizationUserId = Credential.OrganizationUserId;

            var result = _createCustomerRequest.Process(request);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest();
        }

        [Route("{id:int}")]
        public IHttpActionResult Put(
            [FromUri]UpdateCustomerRequest request,
            [FromBody]Delta<WriteCustomerPayload> input)
        {
            //map customer to an updatecustomerrequest so it gets all data
            //input.Patch(updatecustomerrequest) to get the patched value
            //pass patched value to processor
            request.Payload = input;
            request.OrganizationUserId = Credential.OrganizationUserId;

            var customer = _updateRequestProcessor.Process(request);

            return Ok(customer);
        }

        [Route("{id:int}")]
        public IHttpActionResult Delete([FromUri]OrganizationEntityRequest request)
        {
            var result = _deleteRequestProcessor.Process(request);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest();
        }

        [Route("")]
        public IHttpActionResult Delete([FromUri]BulkDeleteCustomersRequest request)
        {
            var result = _bulkDeleteRequestProcessor.Process(request);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest();
        }
    }
}
