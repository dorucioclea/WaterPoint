using AutoMapper;
using Utility;
using WaterPoint.Core.Domain.Contracts.InvoiceCostItems;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.InvoiceCostItems;

namespace WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts
{
    public class InvoiceCostItemMapper
    {
        static InvoiceCostItemMapper()
        {
            Mapper.CreateMap<InvoiceCostItemBasicPoco, BasicInvoiceCostItemContract>()
                .ForMember(o => o.Version, i => i.MapFrom(d => d.Version.ToSha1(d.Id.ToString())));

            Mapper.CreateMap<InvoiceCostItem, InvoiceCostItemContract>()
                .ForMember(o => o.Version, i => i.MapFrom(d => d.Version.ToSha1(d.Id.ToString())));
        }

        public static BasicInvoiceCostItemContract Map(InvoiceCostItemBasicPoco source)
        {
            return Mapper.Map<BasicInvoiceCostItemContract>(source);
        }

        public static InvoiceCostItemContract Map(InvoiceCostItem source)
        {
            return Mapper.Map<InvoiceCostItemContract>(source);
        }
    }
}
