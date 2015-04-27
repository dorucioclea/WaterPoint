using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain.Bll;
using WaterPoint.Data.Entity;
using WaterPoint.Data.Repository;
using WaterPoint.Data.Repository.Interfaces;

namespace WaterPoint.Data.Bll
{
    public class SupplierBll : ISupplierBll
    {
        private readonly ISupplierRepository _supplierRepo;

        public SupplierBll(ISupplierRepository supplierRepo)
        {
            _supplierRepo = supplierRepo;
        }

        public async Task<IEnumerable<Supplier>> ListAsync(int organizationId)
        {
            var result = await Task.Run<IEnumerable<Supplier>>(() => _supplierRepo.ListAllAsync(organizationId));

            return result;
        }

        public async Task<Supplier> GetAsync(int organizationId, int id)
        {
            var supplier = await _supplierRepo.GetAsync(organizationId, id);

            return supplier;
        }
    }
}
