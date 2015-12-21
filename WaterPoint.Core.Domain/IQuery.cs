namespace WaterPoint.Core.Domain
{
    public interface IQuery<in T> where T : IQueryParameter
    {
        void BuildQuery(T parameter);
        string Query { get; }
        object Parameters { get; }
    }

    public interface IListPaginatedWithOrgIdQuery<in T> : IQuery<T>
        where T : IQueryParameter
    {
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

    public interface IQueryRunner<T, TOut>
        where T: IQueryParameter
    {
        TOut Run(IQuery<T> query);
    }
}
