using AutoMapper;
using Utility;
using WaterPoint.Core.Domain.Contracts.Staff;
using WaterPoint.Data.Entity.Pocos.Staff;

namespace WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts
{
    public class StaffMapper
    {
        static StaffMapper()
        {
            Mapper.CreateMap<Data.Entity.DataEntities.Staff, StaffContract>()
                .ForMember(o => o.Version, i => i.MapFrom(d => d.Version.ToSha1(d.Id.ToString())));

            Mapper.CreateMap<BasicStaffPoco, BasicStaffContract>()
                .ForMember(o => o.Version, i => i.MapFrom(d => d.Version.ToSha1(d.Id.ToString())));

            Mapper.CreateMap<JobStaffPoco, JobStaffContract>()
                .ForMember(o => o.Version, i => i.MapFrom(d => d.Version.ToSha1(d.Id.ToString())));
        }

        public static StaffContract Map(Data.Entity.DataEntities.Staff source)
        {
            return Mapper.Map<StaffContract>(source);
        }

        public static BasicStaffContract Map(BasicStaffPoco source)
        {
            return Mapper.Map<BasicStaffContract>(source);
        }

        public static JobStaffContract Map(JobStaffPoco source)
        {
            return Mapper.Map<JobStaffContract>(source);
        }
    }
}
