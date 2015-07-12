using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Contract;

namespace WaterPoint.Api.Domain.Services
{
    public interface IRestaurantService
    {
        Task<RestaurantContract> GetByIdAsync(int restaurantId);
    }
}
