using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WaterPoint.Api.Domain.Services;
using WaterPoint.Core.ContractMapper;
using WaterPoint.Core.Domain.Bll;
using WaterPoint.Core.Contract;
using WaterPoint.Data.Entity;

namespace WaterPoint.Api.Service
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantBll _restaurantBll;

        public RestaurantService(IRestaurantBll restaurantBll)
        {
            _restaurantBll = restaurantBll;
        }

        public async Task<RestaurantContract> GetByIdAsync(int restaurantId)
        {
            var org = await _restaurantBll.GetAsync(restaurantId);

            var result = CoreMapperHelper.MapTo<RestaurantContract>(org);

            return result;
        }
    }
}
