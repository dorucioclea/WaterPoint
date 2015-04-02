using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Api.Contract;
using WaterPoint.Data.Bll.Interfaces;
using WaterPoint.Data.Entity;
using WaterPoint.Data.Service.Interfaces;

namespace WaterPoint.Data.Service
{
    public class SupplierService: ISupplierService
    {
        private readonly ISupplierBll _supplierBll;

        public SupplierService(ISupplierBll supplierBll)
        {
            _supplierBll = supplierBll;
        }

        public IEnumerable<SupplierContract> List()
        {
            var result = _supplierBll.List();
            return null;
        }
    }
}
