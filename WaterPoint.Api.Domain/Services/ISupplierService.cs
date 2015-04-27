using System.Collections.Generic;
using System.Threading.Tasks;
using WaterPoint.Core.Contract;

namespace WaterPoint.Core.Domain.Services
{
    public interface ISupplierService
    {
        Task<IEnumerable<SupplierContract>> ListAsync(int organizationId);

        Task<SupplierContract> GetByIdAsync(int organizationId, int id);
    }
}