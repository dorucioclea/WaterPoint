using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos;

namespace WaterPoint.Core.ContractMapper
{
    public class CustomerMapper
    {
        static CustomerMapper()
        {
            Mapper.CreateMap<CustomerPoco, CustomerContract>();
            Mapper.CreateMap<Customer, CustomerContract>();
        }

        public static CustomerContract Map(Customer source)
        {
            return Mapper.Map<CustomerContract>(source);
        }

        public static CustomerContract Map(CustomerPoco source)
        {
            return Mapper.Map<CustomerContract>(source);
        }
    }
}
