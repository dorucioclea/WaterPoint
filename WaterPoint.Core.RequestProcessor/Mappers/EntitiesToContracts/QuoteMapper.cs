using AutoMapper;
using Utility;
using WaterPoint.Core.Domain.Contracts.Quotes;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.Quotes;

namespace WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts
{
    public class QuoteMapper
    {
        static QuoteMapper()
        {
            Mapper.CreateMap<QuoteBasicPoco, QuoteBasicContract>()
                .ForMember(o => o.Version, i => i.MapFrom(d => d.Version.ToSha1(d.Id.ToString())));

            Mapper.CreateMap<Quote, QuoteContract>()
                .ForMember(o => o.Version, i => i.MapFrom(d => d.Version.ToSha1(d.Id.ToString())));
        }

        public static QuoteBasicContract Map(QuoteBasicPoco source)
        {
            return Mapper.Map<QuoteBasicContract>(source);
        }

        public static QuoteContract Map(Quote source)
        {
            return Mapper.Map<QuoteContract>(source);
        }
    }
}
