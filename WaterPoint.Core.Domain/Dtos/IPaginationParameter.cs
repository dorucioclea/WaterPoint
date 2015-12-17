namespace WaterPoint.Core.Domain.Dtos
{
    public interface IPaginationParamter : IUriQueryParamter
    {
        int? PageSize { get; set; }
        int? PageNumber { get; set; }
        string Sort { get; set; }
        bool? IsDesc { get; set; }
        string SearchTerm { get; set; }
    }
}
