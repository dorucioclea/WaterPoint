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
using WaterPoint.Core.Domain.Requests.Products;
using WaterPoint.Core.Domain.Services;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Api.Controllers
{
    [RoutePrefix("products")]
    public class ProductsController : BaseStoreContextController
    {
        public ProductsController(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }
    }
}
