namespace WaterPoint.Core.Domain.Db
{
    public interface IPagedQueryParameter : ISimplePagedQueryParameter
    {
        string Sort { get; set; }
        bool IsDesc { get; set; }
        string SearchTerm { get; set; }
    }
}