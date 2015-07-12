using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.App.Domain.Services;
using WaterPoint.App.ViewModel;
using WaterPoint.Core.Contract;
using WaterPoint.Core.ContractMapper;
using WaterPoint.Core.Domain.DataProvider;

namespace WaterPoint.App.Service
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantApiDataProvider _restaurantApiDataProvider;

        public RestaurantService(IRestaurantApiDataProvider restaurantApiDataProvider)
        {
            _restaurantApiDataProvider = restaurantApiDataProvider;
        }

        public async Task<RestaurantIndex> RestaurantIndex(int id)
        {
            var restaurant = await _restaurantApiDataProvider.GetByIdAsync(id);
            
            var result = CoreMapperHelper.MapTo<RestaurantIndex>(restaurant);

            return result;
        }
    }
}
