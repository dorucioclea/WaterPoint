using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.Entity;

namespace WaterPoint.Core.Domain.Bll
{
    public interface ITableBll
    {
        Task<IEnumerable<Table>> ListByGroupId(IRestaurantContext currentRestaurant, int groupId);
    }
}
