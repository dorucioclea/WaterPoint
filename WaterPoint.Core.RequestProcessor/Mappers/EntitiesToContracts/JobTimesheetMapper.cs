using AutoMapper;
using Utility;
using WaterPoint.Core.Domain.Contracts.JobTimesheet;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts
{
    public class JobTimesheetMapper
    {
        static JobTimesheetMapper()
        {
            Mapper.CreateMap<JobTimesheet, JobTimesheetContract>()
                .ForMember(o => o.Version, i => i.MapFrom(d => d.Version.ToSha1(d.Id.ToString())));
        }

        public static JobTimesheetContract Map(Data.Entity.DataEntities.JobTimesheet source)
        {
            return Mapper.Map<JobTimesheetContract>(source);
        }
    }
}
