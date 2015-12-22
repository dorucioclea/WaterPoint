using AutoMapper;
using Utility;
using WaterPoint.Core.Domain.Contracts.CostItems;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts
{
    public class CostItemMapper
    {
        static CostItemMapper()
        {
            Mapper.CreateMap<CostItem, CostItemContract>()
                .ForMember(o => o.Version, i => i.MapFrom(d => d.Version.ToSha1(d.Id.ToString()))); ;
        }

        public static CostItemContract Map(CostItem source)
        {
            return Mapper.Map<CostItemContract>(source);
        }
    }
}
