using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WaterPoint.Core.Domain;

namespace WaterPoint.Api.BaseControllers
{
    public abstract class BaseStoreContextController : ApiController
    {
        public IUnitOfWork UnitOfWork { get; private set; }
        //TODO: load from the db;
        protected IStoreContext CurrentRestaurant = new TempContext();

        protected BaseStoreContextController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }

    public class TempContext : IStoreContext
    {

    }
}