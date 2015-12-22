using AutoMapper;
using WaterPoint.Core.Domain.Contracts.Credentials;
using WaterPoint.Data.Entity.Pocos.Views;

namespace WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts
{
    public class CredentialMapper
    {
        static CredentialMapper()
        {
            Mapper.CreateMap<ValidCredential, ValidCredentialContract>();
        }

        public static ValidCredentialContract Map(ValidCredential source)
        {
            return Mapper.Map<ValidCredentialContract>(source);
        }
    }
}
