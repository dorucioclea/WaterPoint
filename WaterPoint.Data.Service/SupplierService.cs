using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.Bll.Interfaces;
using WaterPoint.Data.Entity;
using WaterPoint.Data.Service.Interfaces;
using AutoMapper;
using WaterPoint.App.Domain.DataContracts;

namespace WaterPoint.Data.Service
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierBll _supplierBll;

        public SupplierService(ISupplierBll supplierBll)
        {
            _supplierBll = supplierBll;
        }

        public async Task<IEnumerable<SupplierContract>> ListAsync(int organizationId)
        {
            var list = await _supplierBll.ListAsync(organizationId);

            var result = Mapper.Map<IEnumerable<SupplierContract>>(list);

            return result;
        }

        public async Task<SupplierContract> GetByIdAsync(int organizationId, int id)
        {
            var supplier = await _supplierBll.GetAsync(organizationId, id);

            var result = Mapper.Map<SupplierContract>(supplier);

            return result;
        }
    }
}
