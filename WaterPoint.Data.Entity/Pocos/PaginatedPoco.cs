using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Data.Entity.Pocos
{
    public class PaginatedPoco<T> : PaginatedPoco
        where T : class
    {
        public T Data { get; set; }
    }

    public class PaginatedPoco
    {
        public int TotalCount { get; set; }
    }
}
