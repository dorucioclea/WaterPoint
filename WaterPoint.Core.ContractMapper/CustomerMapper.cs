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
            Mapper.CreateMap<BasicCustomerPoco, BasicCustomer>();
            Mapper.CreateMap<Customer, BasicCustomer>();
            Mapper.CreateMap<BasicCustomerWithAddressPoco, BasicCustomerWithAddress>();
        }

        public static BasicCustomer Map(Customer source)
        {
            return Mapper.Map<BasicCustomer>(source);
        }

        public static BasicCustomer Map(BasicCustomerPoco source)
        {
            return Mapper.Map<BasicCustomer>(source);
        }

        public static BasicCustomerWithAddress Map(BasicCustomerWithAddressPoco source)
        {
            return Mapper.Map<BasicCustomerWithAddress>(source);
        }
    }
}
