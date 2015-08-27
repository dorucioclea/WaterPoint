using System.Collections.Generic;
using System.Threading.Tasks;
using WaterPoint.Data.Entity;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Domain.Bll
{
    public interface IRestaurantBll
    {
        Task<Restaurant> GetAsync(int restaurantId);
    }
}