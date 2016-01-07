using AutoMapper;
using Utility;
using WaterPoint.Core.Domain.Contracts.QuoteTasks;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.QuoteTasks;

namespace WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts
{
    public class QuoteTaskMapper
    {
        static QuoteTaskMapper()
        {
            Mapper.CreateMap<QuoteTaskBasicPoco, QuoteTaskBasicContract>()
                .ForMember(o => o.Version, i => i.MapFrom(d => d.Version.ToSha1(d.Id.ToString())));

            Mapper.CreateMap<QuoteTask, QuoteTaskContract>()
                .ForMember(o => o.Version, i => i.MapFrom(d => d.Version.ToSha1(d.Id.ToString())));
        }

        public static QuoteTaskBasicContract Map(QuoteTaskBasicPoco source)
        {
            return Mapper.Map<QuoteTaskBasicContract>(source);
        }

        public static QuoteTaskContract Map(QuoteTask source)
        {
            return Mapper.Map<QuoteTaskContract>(source);
        }
    }
}
