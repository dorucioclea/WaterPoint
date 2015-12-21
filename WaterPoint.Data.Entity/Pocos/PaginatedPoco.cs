namespace WaterPoint.Data.Entity.Pocos
{
    public class PaginatedPoco<T> : PaginatedPoco
    {
        public T Data { get; set; }
    }

    public class PaginatedPoco
    {
        public const string SplitOnColumn = "TotalCount";
        public int TotalCount { get; set; }
    }
}
