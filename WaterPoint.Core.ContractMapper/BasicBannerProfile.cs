using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WaterPoint.Core.Domain.Contracts.Banners;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.ContractMapper
{
    public class BasicBannerProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Banner, BasicBanner>();
        }
    }
}
