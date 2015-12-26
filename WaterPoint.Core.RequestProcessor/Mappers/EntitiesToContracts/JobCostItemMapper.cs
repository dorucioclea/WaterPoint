using AutoMapper;
using Utility;
using WaterPoint.Core.Domain.Contracts.JobCostItems;
using WaterPoint.Core.Domain.Contracts.JobTasks;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts
{
    public class JobCostItemMapper
    {
        static JobCostItemMapper()
        {
            Mapper.CreateMap<JobCostItem, JobCostItemContract>()
                .ForMember(o => o.Version, i => i.MapFrom(d => d.Version.ToSha1(d.Id.ToString())));
        }

        public static JobCostItemContract Map(JobCostItem source)
        {
            return Mapper.Map<JobCostItemContract>(source);
        }
    }
}
