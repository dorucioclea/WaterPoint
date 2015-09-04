using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Contracts.Products;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.ContractMapper
{
    public class SkuProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Sku, SkuContract>()
                .ForMember(o => o.Product, i => i.MapFrom(f => f.Product));
        }
    }
}
