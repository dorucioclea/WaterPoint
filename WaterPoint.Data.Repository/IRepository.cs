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
        Task<IEnumerable<Supplier>> ListAllAsync();
    }

    public class SupplierRepository : GenericRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(IDbContext dbContext)
            : base(dbContext)
        {

        }

        public async Task<IEnumerable<Supplier>> ListAllAsync()
        {
            var result = await DbContext.ListAsync<Supplier>("select * from supplier where id > @id", new { id = 10 });

            return result;
        }
    }
}
