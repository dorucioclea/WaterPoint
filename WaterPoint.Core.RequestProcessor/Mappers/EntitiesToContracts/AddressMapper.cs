using AutoMapper;
using Utility;
using WaterPoint.Core.Domain.Contracts.Addresses;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts
{
    public class AddressMapper
    {
        static AddressMapper()
        {
            Mapper.CreateMap<Address, AddressContract>()
                .ForMember(o => o.Version, i => i.MapFrom(d => d.Version.ToSha1(d.Id.ToString())));
        }

        public static AddressContract Map(Address source)
        {
            return Mapper.Map<AddressContract>(source);
        }
    }
}
