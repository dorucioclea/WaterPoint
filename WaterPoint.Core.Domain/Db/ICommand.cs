namespace WaterPoint.Core.Domain.Db
{
    public interface ICommand<in T> where T : IQueryParameter
    {
        void BuildQuery(T input);
        string Query { get; }
        object Parameters { get; }
        bool IsStoredProcedure { get; }
    }

    public interface ICommandExecutor
    {
        int Execute<T>(ICommand<T> query) where T : IQueryParameter;
        int NoneQuery<T>(ICommand<T> query) where T : IQueryParameter;
    }
}
