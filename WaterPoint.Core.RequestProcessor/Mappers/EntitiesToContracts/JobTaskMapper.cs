using AutoMapper;
using Utility;
using WaterPoint.Core.Domain.Contracts.JobTasks;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.JobTasks;

namespace WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts
{
    public class JobTaskMapper
    {
        static JobTaskMapper()
        {
            Mapper.CreateMap<JobTask, JobTaskContract>()
                .ForMember(o => o.Version, i => i.MapFrom(d => d.Version.ToSha1(d.Id.ToString())));

            Mapper.CreateMap<JobTaskBasicPoco, JobTaskBasicContract>()
                .ForMember(o => o.Version, i => i.MapFrom(d => d.Version.ToSha1(d.Id.ToString())));
        }

        public static JobTaskContract Map(JobTask source)
        {
            return Mapper.Map<JobTaskContract>(source);
        }

        public static JobTaskBasicContract Map(JobTaskBasicPoco source)
        {
            return Mapper.Map<JobTaskBasicContract>(source);
        }
    }
}
