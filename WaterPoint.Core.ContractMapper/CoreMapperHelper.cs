using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WaterPoint.Core.Contract;
using WaterPoint.Data.Entity;

namespace WaterPoint.Core.ContractMapper
{
    public static class CoreMapperHelper
    {
        public static void Initialize()
        {
            Mapper.Initialize(config =>
            {
                config.AddProfile(new SupplierProfile());
                config.AddProfile(new OrganizationProfile());
            });
        }

        public static TOut Map<TIn, TOut>(TIn source)
        {
            return Mapper.Map<TOut>(source);
        }
    }
}
