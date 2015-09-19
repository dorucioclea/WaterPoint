using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WaterPoint.Api.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Products;
using WaterPoint.Core.Domain.SpecificationRequests.Products;
using WaterPoint.Core.Domain.Specifications;
using WaterPoint.Core.RequestProcessor;

namespace WaterPoint.Api.Controllers
{
    [RoutePrefix(RouteDefinitions.Flags.Prefix)]
    public class FlagsController : BaseShopContextController
    {
        private readonly IRequestProcessor<ListProductsByFlagRequest, IEnumerable<BasicProduct>> _listProductsByFlagProcessor;

        //private readonly ISpecification<ListProductsByFlag, IEnumerable<Product>> _listProductsByFlagService;

        public FlagsController(
            IUnitOfWork unitOfWork,
            IRequestProcessor<ListProductsByFlagRequest, IEnumerable<BasicProduct>> listProductsByFlagProcessor)
            : base(unitOfWork)
        {
            _listProductsByFlagProcessor = listProductsByFlagProcessor;
        }

        [Route(RouteDefinitions.Flags.GetProducts)]
        public IHttpActionResult GetProducts([FromUri]ListProductsByFlagRequest request)
        {
            var isRequestValid = true;

            if (!isRequestValid)
            {
                return BadRequest();
            }
            using (UnitOfWork.Begin())
            {
                var result = _listProductsByFlagProcessor.Process(request);

                return Ok(result);
            }
        }
    }
}
