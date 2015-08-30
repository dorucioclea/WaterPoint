using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WaterPoint.Api.BaseControllers;
using WaterPoint.Core.Cqrs.Queries;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Services;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Api.Controllers
{
    [RoutePrefix("products")]
    public class ProductsController : BaseStoreContextController
    {
        private readonly IProductService _productService;
        private readonly IQueryDispatcher<ListProductsByFlagQuery, IEnumerable<Product>> _listProductsByFlagQueryDispatcher;

        public ProductsController(
            IUnitOfWork unitOfWork,
            IProductService productService,
            IQueryDispatcher<ListProductsByFlagQuery, IEnumerable<Product>> listProductsByFlagQueryDispatcher)
            : base(unitOfWork)
        {
            _productService = productService;
            _listProductsByFlagQueryDispatcher = listProductsByFlagQueryDispatcher;
        }

        [Route("{flagId:int}")]
        public IHttpActionResult Get(ListProductsByFlagQuery query)
        {
            var isValidated = true;

            if (!isValidated)
            {
                return Ok();
            }

            var result =_listProductsByFlagQueryDispatcher.Dispatch(query);

            _productService.Run<ListProductsByFlagQuery, IEnumerable<ProductContract>>(query);

            return Ok(result);
        }
    }
}
