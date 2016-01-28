using System.Web.Http;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Suppliers;
using WaterPoint.Core.Domain.Payloads.Suppliers;
using WaterPoint.Core.Domain.Requests.Suppliers;

namespace WaterPoint.Api.Supplier.Controllers
{
    [Authorize]
    [RoutePrefix("organizations/{organizationId:int}/suppliers")]
    public class SuppliersController : BaseOrgnizationContextController
    {
        private readonly IPagedProcessor<ListSuppliersRequest, SupplierContract> _listSupplierRequestProcessor;
        //private readonly IRequestProcessor<GetSupplierByIdRequest, SupplierDetailsContract> _getSupplierByIdRequestProcessor;
        private readonly IWriteRequestProcessor<CreateSupplierRequest> _createSupplierRequestProcessor;
        //private readonly IWriteRequestProcessor<UpdateSupplierRequest> _updateSupplierRequestProcessor;

        public SuppliersController(
            IPagedProcessor<ListSuppliersRequest, SupplierContract> listSupplierRequestProcessor,
            //IRequestProcessor<GetSupplierByIdRequest, SupplierDetailsContract> getSupplierByIdRequestProcessor,
            //IWriteRequestProcessor<UpdateSupplierRequest> updateSupplierRequestProcessor,
            IWriteRequestProcessor<CreateSupplierRequest> createSupplierRequestProcessor
            )
        {
            _listSupplierRequestProcessor = listSupplierRequestProcessor;
            //_getSupplierByIdRequestProcessor = getSupplierByIdRequestProcessor;
            _createSupplierRequestProcessor = createSupplierRequestProcessor;
            //_updateSupplierRequestProcessor = updateSupplierRequestProcessor;
        }

        [Route("")]
        public IHttpActionResult Get([FromUri]ListSuppliersRequest request)
        {
            var result = _listSupplierRequestProcessor.Process(request);

            return Ok(result);
        }

        //[Route("{id:int}")]
        //public IHttpActionResult Get([FromUri]GetSupplierByIdRequest request)
        //{
        //    var result = _getSupplierByIdRequestProcessor.Process(request);

        //    return Ok(result);
        //}


        [Route("")]
        public IHttpActionResult Post(
            [FromUri]CreateSupplierRequest request,
            [FromBody]CreateSupplierPayload supplierPayload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestWithErrors(ModelState);
            }

            request.Payload = supplierPayload;
            request.OrganizationUserId = Credential.OrganizationUserId;

            var result = _createSupplierRequestProcessor.Process(request);

            return Ok(result);
        }

        //[Route("{id:int}")]
        //public IHttpActionResult Put(
        //    [FromUri]UpdateSupplierRequest request,
        //    [FromBody]Delta<WriteSupplierPayload> input)
        //{
        //    request.OrganizationUserId = Credential.OrganizationUserId;
        //    request.Payload = input;

        //    var supplier = _updateSupplierRequestProcessor.Process(request);

        //    return Ok(supplier);
        //}
    }
}
