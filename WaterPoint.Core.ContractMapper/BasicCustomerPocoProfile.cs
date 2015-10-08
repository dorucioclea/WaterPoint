using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Data.Entity.Pocos;

namespace WaterPoint.Core.ContractMapper
{
    public class BasicCustomerPocoProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<BasicCustomerPoco, BasicCustomer>();
        }
    }
}
