namespace WaterPoint.Core.Domain.Db
{
    public interface ISimplePagedQueryParameter : IQueryParameter
    {
        int Offset { get; set; }
        int PageSize { get; set; }
        int PageNumber { get; set; }
    }
}