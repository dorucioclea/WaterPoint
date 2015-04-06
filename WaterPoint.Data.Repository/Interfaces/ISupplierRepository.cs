using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.Entity;

namespace WaterPoint.Data.Repository.Interfaces
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<Supplier>> ListAllAsync(int organizationId);

        Task<Supplier> GetAsync(int organizationId, int id);
    }
}
