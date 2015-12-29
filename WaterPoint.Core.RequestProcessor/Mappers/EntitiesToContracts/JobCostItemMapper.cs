using AutoMapper;
using Utility;
using WaterPoint.Core.Domain.Contracts.JobCostItems;
using WaterPoint.Core.Domain.Contracts.JobTasks;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.JobCostItems;

namespace WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts
{
    public class JobCostItemMapper
    {
        static JobCostItemMapper()
        {
            Mapper.CreateMap<JobCostItem, JobCostItemContract>()
                .ForMember(o => o.Version, i => i.MapFrom(d => d.Version.ToSha1(d.Id.ToString())));

            Mapper.CreateMap<JobCostItemListPoco, JobCostItemBasicContract>()
                .ForMember(o => o.Version, i => i.MapFrom(d => d.Version.ToSha1(d.Id.ToString())));
        }

        public static JobCostItemContract Map(JobCostItem source)
        {
            return Mapper.Map<JobCostItemContract>(source);
        }

        public static JobCostItemBasicContract Map(JobCostItemListPoco source)
        {
            return Mapper.Map<JobCostItemBasicContract>(source);
        }
    }
}
