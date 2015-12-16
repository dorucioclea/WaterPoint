using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Utility;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Core.Domain.Dtos.Requests.Customers;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.Customers;

namespace WaterPoint.Core.RequestProcessor.Mappers
{
    ////not bothered
    //public class CreateCustomerPocoMapper
    //{
    //    static CreateCustomerPocoMapper()
    //    {
    //        Mapper.CreateMap<CreateCustomerRequest, CreateCustomerPoco>()
    //            .ForMember(o => o.OrganizationId, i => i.MapFrom(d => d.OrganizationIdParameter.OrganizationId))
    //            .ForMember(o => o.Code, i => i.MapFrom(d => d.CreateCustomerPayload.Code))
    //            .ForMember(o => o.CustomerTypeId, i => i.MapFrom(d => d.CreateCustomerPayload.CustomerTypeId))
    //            .ForMember(o => o.Dob, i => i.MapFrom(d => d.CreateCustomerPayload.Dob));
    //    }

    //    public static CustomerContract Map(CreateCustomerPoco source)
    //    {
    //        return Mapper.Map<CustomerContract>(source);
    //    }
    //}
}
