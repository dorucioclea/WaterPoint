using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WaterPoint.Core.Domain;

namespace WaterPoint.Api.BaseControllers
{
    public abstract class BaseRestaurantContextController : ApiController
    {
        public IUnitOfWork UnitOfWork { get; private set; }
        //TODO: load from the db;
        protected IRestaurantContext CurrentRestaurant = new TempContext();

        protected BaseRestaurantContextController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }

    public class TempContext : IRestaurantContext
    {

        public int RestaurantId
        {
            get { return 1; }
        }

        public int BranchId
        {
            get { return 1; }
        }

        public int StaffId
        {
            get { return 1; }
        }
    }
}
