using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.Bll.Interfaces;
using WaterPoint.Data.Entity;

namespace WaterPoint.Data.Bll
{
    public class SupplierBll: ISupplierBll
    {
        public IEnumerable<Supplier> List()
        {
            return Enumerable.Range(1, 10).Select(i => new Supplier { Id = i, Name = "supplier " + i });
        }
    }
}
