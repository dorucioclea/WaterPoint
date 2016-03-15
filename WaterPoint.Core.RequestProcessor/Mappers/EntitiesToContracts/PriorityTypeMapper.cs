using AutoMapper;
using WaterPoint.Core.Domain.Contracts.Jobs;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts
{
    public class PriorityTypeMapper
    {
        static PriorityTypeMapper()
        {
            Mapper.CreateMap<PriorityType, PriorityTypeContract>();
        }

        public static PriorityTypeContract Map(PriorityType source)
        {
            return Mapper.Map<PriorityTypeContract>(source);
        }
    }
}
