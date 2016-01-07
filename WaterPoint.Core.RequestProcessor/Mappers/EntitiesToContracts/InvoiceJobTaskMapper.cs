using AutoMapper;
using Utility;
using WaterPoint.Core.Domain.Contracts.InvoiceJobTasks;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.InvoiceJobTasks;

namespace WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts
{
    public class InvoiceJobTaskMapper
    {
        static InvoiceJobTaskMapper()
        {
            Mapper.CreateMap<InvoiceJobTaskBasicPoco, InvoiceJobTaskBasicContract>()
                .ForMember(o => o.Version, i => i.MapFrom(d => d.Version.ToSha1(d.Id.ToString())));

            Mapper.CreateMap<InvoiceJobTask, InvoiceJobTaskContract>()
                .ForMember(o => o.Version, i => i.MapFrom(d => d.Version.ToSha1(d.Id.ToString())));
        }

        public static InvoiceJobTaskBasicContract Map(InvoiceJobTaskBasicPoco source)
        {
            return Mapper.Map<InvoiceJobTaskBasicContract>(source);
        }

        public static InvoiceJobTaskContract Map(InvoiceJobTask source)
        {
            return Mapper.Map<InvoiceJobTaskContract>(source);
        }
    }
}
