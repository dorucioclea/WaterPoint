namespace WaterPoint.Core.Domain.Db
{
    public interface ICommand<in T> where T : IQueryParameter
    {
        void BuildQuery(T input);
        string Query { get; }
        object Parameters { get; }
    }

    public interface ICommandExecutor<T> where T : IQueryParameter
    {
        int Execute(ICommand<T> query);
    }
}
