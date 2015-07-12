using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Contract;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.DataProvider;

namespace WaterPoint.App.DataProvider
{
    //TODO: bind uri to apiclient
    public class RestaurantApiDataProvider : ApiDataProvider, IRestaurantApiDataProvider
    {
        private const string Restaurants = "restaurants";

        public RestaurantApiDataProvider(IApiClient client)
            : base(client)
        {
            Client.Context.AppendToUri(Restaurants);
        }

        public async Task<RestaurantContract> GetByIdAsync(int id)
        {
            Client.Context.AppendToUri(id);

            var result = await Client.Get<RestaurantContract>();

            return result;
        }
    }
}
