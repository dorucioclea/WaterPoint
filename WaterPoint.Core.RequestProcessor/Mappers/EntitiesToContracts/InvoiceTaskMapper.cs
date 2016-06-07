using AutoMapper;
using Utility;
using WaterPoint.Core.Domain.Contracts.InvoiceTasks;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.InvoiceTasks;

namespace WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts
{
    public class InvoiceTaskMapper
    {
        static InvoiceTaskMapper()
        {
            Mapper.CreateMap<InvoiceTaskBasicPoco, InvoiceTaskBasicContract>()
                .ForMember(o => o.Version, i => i.MapFrom(d => d.Version.ToSha1(d.Id.ToString())));

            Mapper.CreateMap<InvoiceTask, InvoiceTaskContract>()
                .ForMember(o => o.Version, i => i.MapFrom(d => d.Version.ToSha1(d.Id.ToString())));
        }

        public static InvoiceTaskBasicContract Map(InvoiceTaskBasicPoco source)
        {
            return Mapper.Map<InvoiceTaskBasicContract>(source);
        }

        public static InvoiceTaskContract Map(InvoiceTask source)
        {
            return Mapper.Map<InvoiceTaskContract>(source);
        }
    }
}
