using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.Entity;
using WaterPoint.Data.Service.Interfaces;

namespace WaterPoint.Data.Service
{
    public class SupplierService: ISupplierService
    {
        public IEnumerable<Supplier> List()
        {
            return Enumerable.Range(1, 10).Select(i => new Supplier { Id = i, Name = "supplier " + i });
        }
    }
}
