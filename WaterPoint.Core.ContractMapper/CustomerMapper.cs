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
            Mapper.CreateMap<BasicCustomerPoco, BasicCustomerContract>();
            Mapper.CreateMap<Customer, BasicCustomerContract>();
        }

        public static BasicCustomerContract Map(Customer source)
        {
            return Mapper.Map<BasicCustomerContract>(source);
        }

        public static BasicCustomerContract Map(BasicCustomerPoco source)
        {
            return Mapper.Map<BasicCustomerContract>(source);
        }
    }
}
