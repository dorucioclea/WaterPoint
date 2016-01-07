namespace WaterPoint.Core.Domain.RequestParameters
{
    public interface IPaginationRequest : ISimplePagedRequest
    {
        string Sort { get; set; }
        bool? IsDesc { get; set; }
        string SearchTerm { get; set; }
    }

    public interface ISimplePagedRequest : IRequest
    {
        int? PageSize { get; set; }
        int? PageNumber { get; set; }
    }
}
