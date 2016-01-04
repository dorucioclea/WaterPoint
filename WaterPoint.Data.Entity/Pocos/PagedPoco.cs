using System.Collections.Generic;

namespace WaterPoint.Data.Entity.Pocos
{
    public class PagedPoco<T> : PagedPoco
    {
        public T Data { get; set; }
    }

    public class PagedPoco : IDataEntity
    {
        public const string SplitOnColumn = "TotalCount";
        public int TotalCount { get; set; }
    }
}
