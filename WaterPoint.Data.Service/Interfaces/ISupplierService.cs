using System.Collections.Generic;
using WaterPoint.Api.Contract;
using WaterPoint.Data.Entity;

namespace WaterPoint.Data.Service.Interfaces
{
    public interface ISupplierService
    {
        IEnumerable<SupplierContract> List();
    }
}