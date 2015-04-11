using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WaterPoint.Api.Contract;
using WaterPoint.Data.Entity;

namespace WaterPoint.Data.ContractMapper
{
    public static class ContractMapper
    {
        public static void Initialize()
        {
            Mapper.Initialize(config =>
            {
                config.AddProfile(new SupplierProfile());
            });

            
        }

        public class SupplierProfile : Profile
        {
            protected override void Configure()
            {
                Mapper.CreateMap<Supplier, SupplierContract>();
                    //.ForMember((su)=>su.DisplayName,;
            }
        }
    }
}
