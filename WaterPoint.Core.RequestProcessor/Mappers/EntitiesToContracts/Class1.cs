using AutoMapper;
using Utility;
using WaterPoint.Core.Domain.Contracts.QuoteTasks;
using WaterPoint.Data.Entity.Pocos.QuoteTasks;

namespace WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts
{
    public class QuoteTaskMapper
    {
        static QuoteTaskMapper()
        {
            Mapper.CreateMap<QuoteTaskBasicPoco, QuoteTaskBasicContract>()
                .ForMember(o => o.Version, i => i.MapFrom(d => d.Version.ToSha1(d.Id.ToString()))); ;
        }

        public static QuoteTaskBasicContract Map(QuoteTaskBasicPoco source)
        {
            return Mapper.Map<QuoteTaskBasicContract>(source);
        }
    }
}
