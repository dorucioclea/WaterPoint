using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.Bll.QueryParameters
{
    public interface IPaginatedQueryParameter : IQueryParameter
    {
        int Offset { get; set; }
        int PageSize { get; set; }
        string Sort { get; set; }
        bool IsDesc { get; set; }
        string SearchTerm { get; set; }
    }
}
