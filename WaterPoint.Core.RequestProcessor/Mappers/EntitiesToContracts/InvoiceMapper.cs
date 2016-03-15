using AutoMapper;
using Utility;
using WaterPoint.Core.Domain.Contracts.Invoices;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts
{
    public class InvoiceMapper
    {
        static InvoiceMapper()
        {
            Mapper.CreateMap<Invoice, InvoiceContract>()
                .ForMember(o => o.Version, i => i.MapFrom(d => d.Version.ToSha1(d.Id.ToString())));
        }

        public static InvoiceContract Map(Invoice source)
        {
            return Mapper.Map<InvoiceContract>(source);
        }
    }
}
