namespace WaterPoint.Data.Entity.Pocos
{
    public class PaginatedPoco<T> : PaginatedPoco
        where T : class
    {
        public T Data { get; set; }
    }

    public class PaginatedPoco
    {
        public const string SplitOnColumn = "TotalCount";
        public int TotalCount { get; set; }
    }
}
