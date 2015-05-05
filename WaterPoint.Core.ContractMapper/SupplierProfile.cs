﻿using AutoMapper;
using WaterPoint.Core.Contract;
using WaterPoint.Data.Entity;

namespace WaterPoint.Core.ContractMapper
{
    public class SupplierProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Supplier, SupplierContract>();
            //.ForMember((su)=>su.DisplayName,;
        }
    }
}