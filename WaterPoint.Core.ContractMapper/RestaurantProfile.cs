using AutoMapper;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Data.Entity;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.ContractMapper
{
    internal class RestaurantProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Restaurant, RestaurantContract>();
        }
    }
}
