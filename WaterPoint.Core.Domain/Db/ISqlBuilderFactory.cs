namespace WaterPoint.Core.Domain.Db
{
    public interface ISqlBuilderFactory
    {
        T Create<T>() where T : ISqlBuilder;
    }
}
