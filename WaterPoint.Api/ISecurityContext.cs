﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Api
{
    public interface ISecurityContext
    {
        int RestaurantId { get; set; }
        int StaffId { get; set; }
    }
}
