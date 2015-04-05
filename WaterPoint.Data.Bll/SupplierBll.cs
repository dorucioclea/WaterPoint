using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.Bll.Interfaces;
using WaterPoint.Data.Entity;
using WaterPoint.Data.Repository;

namespace WaterPoint.Data.Bll
{
    public class SupplierBll : ISupplierBll
    {
        private readonly ISupplierRepository _supplierRepo;

        public SupplierBll(ISupplierRepository supplierRepo)
        {
            _supplierRepo = supplierRepo;
        }

        public async Task<IEnumerable<Supplier>> ListAsync()
        {
            return await Task.Run<IEnumerable<Supplier>>(() => _supplierRepo.ListAllAsync());
        }
    }
}
