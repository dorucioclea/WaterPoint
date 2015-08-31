using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Repositories;
using WaterPoint.Core.Repository;
using WaterPoint.Data.DbContext;
using WaterPoint.Data.DbContext.NHibernate;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(
            ISessionUnitOfWork sessionUnitOfWork)
            : base(sessionUnitOfWork)
        {
        }

        public IEnumerable<Product> ListProductsByFlag(int flagId)
        {
            throw new NotImplementedException();
        }
    }
}
