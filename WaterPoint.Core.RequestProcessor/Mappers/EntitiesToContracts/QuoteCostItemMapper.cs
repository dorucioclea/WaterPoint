using AutoMapper;
using Utility;
using WaterPoint.Core.Domain.Contracts.QuoteCostItems;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.QuoteCostItems;

namespace WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts
{
    public class QuoteCostItemMapper
    {
        static QuoteCostItemMapper()
        {
            Mapper.CreateMap<QuoteCostItemBasicPoco, QuoteCostItemBasicContract>()
                .ForMember(o => o.Version, i => i.MapFrom(d => d.Version.ToSha1(d.Id.ToString())));

            Mapper.CreateMap<QuoteCostItem, QuoteCostItemContract>()
                .ForMember(o => o.Version, i => i.MapFrom(d => d.Version.ToSha1(d.Id.ToString())));
        }

        public static QuoteCostItemBasicContract Map(QuoteCostItemBasicPoco source)
        {
            return Mapper.Map<QuoteCostItemBasicContract>(source);
        }

        public static QuoteCostItemContract Map(QuoteCostItem source)
        {
            return Mapper.Map<QuoteCostItemContract>(source);
        }
    }
}
