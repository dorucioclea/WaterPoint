namespace WaterPoint.Core.Domain
{
    public interface IQuery
    {
        string Query { get; }
        object Parameters { get; }
    }

    public interface IListPaginatedWithOrgIdQuery<in T> : IQuery
        where T : IQueryParameter
    {
        void BuildQuery(T parameter);
    }

    public interface IQueryParameter
    {
    }

    public interface IPaginatedQueryParameter : IQueryParameter
    {
        int Offset { get; set; }
        int PageSize { get; set; }
        string Sort { get; set; }
        bool IsDesc { get; set; }
        string SearchTerm { get; set; }
    }
}
