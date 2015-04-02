using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WaterPoint.Api.Contract;
using WaterPoint.Data.Entity;

namespace WaterPoint.Data.EntityContractMapper
{
    public class Mappera
    {
        static Mappera()
        {
            Mapper.CreateMap<Supplier, SupplierContract>();
        }
    }
}
