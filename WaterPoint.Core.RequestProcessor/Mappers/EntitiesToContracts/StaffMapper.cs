using AutoMapper;
using Utility;
using WaterPoint.Core.Domain.Contracts.Staff;

namespace WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts
{
    public class StaffMapper
    {
        static StaffMapper()
        {
            Mapper.CreateMap<Data.Entity.DataEntities.Staff, StaffContract>()
                .ForMember(o => o.Version, i => i.MapFrom(d => d.Version.ToSha1(d.Id.ToString())));
        }

        public static StaffContract Map(Data.Entity.DataEntities.Staff source)
        {
            return Mapper.Map<StaffContract>(source);
        }
    }
}
