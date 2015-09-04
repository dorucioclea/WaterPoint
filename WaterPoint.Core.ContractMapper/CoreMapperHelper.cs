﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

using WaterPoint.Data.Entity;

namespace WaterPoint.Core.ContractMapper
{
    public static class CoreMapperHelper
    {
        public static void Initialize()
        {
            Mapper.Initialize(config =>
            {
                config.AddProfile(new ProductProfile());
                config.AddProfile(new SkuProfile());
            });
        }

        public static T MapTo<T>(object source)
        {
            return Mapper.Map<T>(source);
        }
    }
}
