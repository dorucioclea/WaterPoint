using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Domain.Repositories
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        IList<Product> ListProductsByFlag(int flagId);
    }
}
