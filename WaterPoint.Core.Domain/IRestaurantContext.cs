﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Core.Domain
{
    public interface IRestaurantContext
    {
        int RestaurantId { get; }
        int BranchId { get; }
        
        int StaffId { get; }
    }
}