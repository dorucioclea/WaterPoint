namespace WaterPoint.Core.Domain.RequestParameters
{
    public interface IPagination : ISimplePagination
    {
        string Sort { get; set; }
        bool? IsDesc { get; set; }
        string SearchTerm { get; set; }
    }

    public interface ISimplePagination : IRequest
    {
        int? PageSize { get; set; }
        int? PageNumber { get; set; }
    }
}
