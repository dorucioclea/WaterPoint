namespace WaterPoint.Core.Domain.Db
{
    public interface ISqlBuilder
    {
        string GetSql();
    }

    public interface ISelectSqlBuilder : ISqlBuilder
    {
    }

    public interface ICreateSqlBuilder : ISqlBuilder
    {

    }

    public interface IUpdateSqlBuilder : ISqlBuilder
    {
    }

    public interface IDeleteSqlBuilder : ISqlBuilder
    {
    }
}
