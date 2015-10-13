using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WaterPoint.App.Domain.ApiContracts;
using WaterPoint.App.Domain.ViewModels.Customers;
using WaterPoint.App.Domain.ViewModels.Customers.Partials;

namespace WaterPoint.App.ViewModelMapper
{
    public class BasicCustomerProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<BasicCustomer, BasicCustomerInfo>();
        }
    }
}
