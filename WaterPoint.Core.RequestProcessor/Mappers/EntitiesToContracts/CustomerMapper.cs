using AutoMapper;
using Utility;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts
{
    public class CustomerMapper
    {
        static CustomerMapper()
        {
            Mapper.CreateMap<Customer, CustomerContract>()
                .ForMember(o => o.Version, i => i.MapFrom(d => d.Version.ToSha1(d.Id.ToString())));
        }

        public static CustomerContract Map(Customer source)
        {
            return Mapper.Map<CustomerContract>(source);
        }
    }
}
