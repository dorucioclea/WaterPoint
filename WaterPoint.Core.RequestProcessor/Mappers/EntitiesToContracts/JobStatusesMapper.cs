using AutoMapper;
using Utility;
using WaterPoint.Core.Domain.Contracts.JobStatuses;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts
{
    public class JobStatusesMapper
    {
        static JobStatusesMapper()
        {
            Mapper.CreateMap<JobStatus, JobStatusContract>()
                .ForMember(o => o.Version, i => i.MapFrom(d => d.Version.ToSha1(d.Id.ToString())));
        }

        public static JobStatusContract Map(JobStatus source)
        {
            return Mapper.Map<JobStatusContract>(source);
        }
    }
}
