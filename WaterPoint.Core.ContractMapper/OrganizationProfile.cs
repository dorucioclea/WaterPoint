using AutoMapper;
using WaterPoint.Core.Contract;
using WaterPoint.Data.Entity;

namespace WaterPoint.Core.ContractMapper
{
    public class OrganizationProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Organization, OrganizationContract>();
        }
    }
}
