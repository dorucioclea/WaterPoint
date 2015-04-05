using System.Collections.Generic;
using System.Threading.Tasks;
using WaterPoint.Api.Contract;
using WaterPoint.Data.Entity;

namespace WaterPoint.Data.Service.Interfaces
{
    public interface ISupplierService
    {
        Task<IEnumerable<SupplierContract>> ListAsync();
    }
}