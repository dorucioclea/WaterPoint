namespace WaterPoint.Data.DbContext.Dapper
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
}
