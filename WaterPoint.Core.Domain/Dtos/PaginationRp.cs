namespace WaterPoint.Core.Domain.Dtos
{
    public class PaginationRp : IPaginationParamter
    {
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
        public string Sort { get; set; }
        public bool? IsDesc { get; set; }
        public string SearchTerm { get; set; }
    }
}
