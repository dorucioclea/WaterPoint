﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Data.DbContext.Dapper
{
    public interface IQuery
    {
        string Query { get; }
        object Parameters { get; }
    }
}