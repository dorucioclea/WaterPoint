using System.Collections.Generic;
using WaterPoint.Data.Entity;

namespace WaterPoint.Data.Service.Interfaces
{
    public interface ISupplierService
    {
        IEnumerable<Supplier> List();
    }
}