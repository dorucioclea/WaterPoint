using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using WaterPoint.Core.Domain;

namespace WaterPoint.Api.BaseControllers
{
    public abstract class BaseShopContextController : ApiController
    {
        public IUnitOfWork UnitOfWork { get; private set; }
        //TODO: load from the db;

        protected BaseShopContextController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}