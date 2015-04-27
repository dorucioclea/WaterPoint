using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.Entity;
using AutoMapper;
using WaterPoint.Core.Domain.Services;
using WaterPoint.Core.Domain.Bll;
using WaterPoint.Core.Contract;

namespace WaterPoint.Api.Service
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
