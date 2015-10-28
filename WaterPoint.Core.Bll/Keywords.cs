using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using WaterPoint.Data.Entity;
using WaterPoint.Data.Entity.Attributes;

namespace WaterPoint.Core.Bll
{
    internal static class SqlPatterns
    {
        internal const string
            Columns = "/**COLUMNS**/",
            FromTable = "/**FromTABLE**/",
            TotalCount = "/**TOTALCOUNT**/",
            Where = "/**WHERE**/",
            OrderBy = "/**ORDERBY**/",
            OrderDesc = "/**ORDERDESC**/",
            Fetch = "/**FETCH**/",
            Join = "/**JOIN**/",
            Values = "/**VALUES**";

    }
}
