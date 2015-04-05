using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.DbContext;
using WaterPoint.Data.Entity;

namespace WaterPoint.Data.Repository
{
    public interface IRepository
    {
    }

    public abstract class GenericRepository<T> where T : class
    {
        protected IDbContext DbContext { get; set; }

        protected GenericRepository(IDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async virtual Task<T> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async virtual Task<T> Save(T obj)
        {
            throw new NotImplementedException();
        }
    }

    public interface ISupplierRepository
    {
    }

    public class SupplierRepository : GenericRepository<Supplier>, ISupplierRepository
    {

    }
}
