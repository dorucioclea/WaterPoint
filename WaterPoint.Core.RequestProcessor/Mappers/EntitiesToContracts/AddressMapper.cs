using AutoMapper;
using Utility;
using WaterPoint.Core.Domain.Contracts.Addresses;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.Addresses;

namespace WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts
{
    public class AddressMapper
    {
        static AddressMapper()
        {
            Mapper.CreateMap<Address, AddressContract>()
                .ForMember(o => o.Version, i => i.MapFrom(d => d.Version.ToSha1(d.Id.ToString())));

            Mapper.CreateMap<CustomerAddressPoco, CustomerAddressContract>()
                .ForMember(o => o.Version, i => i.MapFrom(d => d.Version.ToSha1(d.Id.ToString())));
        }

        public static AddressContract Map(Address source)
        {
            return Mapper.Map<AddressContract>(source);
        }

        public static CustomerAddressContract Map(CustomerAddressPoco source)
        {
            return Mapper.Map<CustomerAddressContract>(source);
        }
    }
}
