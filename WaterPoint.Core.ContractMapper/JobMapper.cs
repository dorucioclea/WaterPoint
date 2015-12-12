using AutoMapper;
using Utility;
using WaterPoint.Core.Domain.Contracts.Jobs;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.ContractMapper
{
    public class JobMapper
    {
        static JobMapper()
        {
            Mapper.CreateMap<Job, JobContract>()
                .ForMember(o => o.Version, i => i.MapFrom(d => d.Version.ToSha1(d.Id.ToString())));
        }

        public static JobContract Map(Job source)
        {
            return Mapper.Map<JobContract>(source);
        }
    }
}
