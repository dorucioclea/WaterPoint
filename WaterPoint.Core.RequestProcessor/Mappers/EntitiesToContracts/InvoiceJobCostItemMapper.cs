using AutoMapper;
using Utility;
using WaterPoint.Core.Domain.Contracts.InvoiceJobCostItems;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.InvoiceJobCostItems;

namespace WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts
{
    public class InvoiceJobCostItemMapper
    {
        static InvoiceJobCostItemMapper()
        {
            Mapper.CreateMap<InvoiceJobCostItemBasicPoco, InvoiceJobCostItemBasicContract>()
                .ForMember(o => o.Version, i => i.MapFrom(d => d.Version.ToSha1(d.Id.ToString())));

            Mapper.CreateMap<InvoiceJobCostItem, InvoiceJobCostItemContract>()
                .ForMember(o => o.Version, i => i.MapFrom(d => d.Version.ToSha1(d.Id.ToString())));
        }

        public static InvoiceJobCostItemBasicContract Map(InvoiceJobCostItemBasicPoco source)
        {
            return Mapper.Map<InvoiceJobCostItemBasicContract>(source);
        }

        public static InvoiceJobCostItemContract Map(InvoiceJobCostItem source)
        {
            return Mapper.Map<InvoiceJobCostItemContract>(source);
        }
    }
}
