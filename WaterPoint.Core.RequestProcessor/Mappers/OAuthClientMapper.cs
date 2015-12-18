using AutoMapper;
using Utility;
using WaterPoint.Core.Domain.Contracts.OAuthClients;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.Mappers
{
    public class OAuthClientMapper
    {
        static OAuthClientMapper()
        {
            Mapper.CreateMap<OAuthClient, OAuthClientContract>()
                .ForMember(o => o.Version, i => i.MapFrom(d => d.Version.ToSha1(d.Id.ToString())));
        }

        public static OAuthClientContract Map(OAuthClient source)
        {
            return Mapper.Map<OAuthClientContract>(source);
        }
    }
}
