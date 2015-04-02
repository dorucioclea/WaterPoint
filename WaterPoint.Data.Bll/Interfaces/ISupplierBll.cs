using System.Collections.Generic;
using WaterPoint.Data.Entity;

namespace WaterPoint.Data.Bll.Interfaces
{
    public interface ISupplierBll
    {
        IEnumerable<Supplier> List();
    }
}