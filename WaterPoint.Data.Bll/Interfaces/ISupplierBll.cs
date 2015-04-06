using System.Collections.Generic;
using System.Threading.Tasks;
using WaterPoint.Data.Entity;

namespace WaterPoint.Data.Bll.Interfaces
{
    public interface ISupplierBll
    {
        Task<IEnumerable<Supplier>> ListAsync(int organizationId);

        Task<Supplier> GetAsync(int organizationId, int id);
    }
}