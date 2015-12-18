using AutoMapper;
using Utility;
using WaterPoint.Core.Domain.Contracts.JobTasks;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.Mappers
{
    public class JobTaskMapper
    {
        static JobTaskMapper()
        {
            Mapper.CreateMap<JobTask, JobTaskContract>()
                .ForMember(o => o.Version, i => i.MapFrom(d => d.Version.ToSha1(d.Id.ToString())));
        }

        public static JobTaskContract Map(JobTask source)
        {
            return Mapper.Map<JobTaskContract>(source);
        }
    }
}
