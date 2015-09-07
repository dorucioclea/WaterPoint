using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WaterPoint.Api.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;

namespace WaterPoint.Api.Controllers
{
    [RoutePrefix("products")]
    public class ProductsController : BaseShopContextController
    {
        public ProductsController(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }
    }
}
