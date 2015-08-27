using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain.Repositories;
using WaterPoint.Core.Repository;
using WaterPoint.Data.DbContext;
using WaterPoint.Data.DbContext.NHibernate;
using WaterPoint.Data.Entity;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Repository
{
    public class RestaurantRepository : RepositoryBase<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(ISessionUnitOfWork sessionUnitOfWork)
            : base(sessionUnitOfWork)
        {
        }

        public async Task<Restaurant> GetAsync(int id)
        {
            //var result = await DbContext.QueryAsync<Restaurant>(RestaurantScripts.GetAsync, new { id });

            //return result.FirstOrDefault();

            return await Task.Run(() => new Restaurant
            {
                Id = id,
                Name = "water point ltd"
            });
        }
    }
}
