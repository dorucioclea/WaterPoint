namespace WaterPoint.Core.Domain.RequestParameters
{
    public interface IPagination
    {
        int? PageSize { get; set; }
        int? PageNumber { get; set; }
        string Sort { get; set; }
        bool? IsDesc { get; set; }
        string SearchTerm { get; set; }
    }
}
