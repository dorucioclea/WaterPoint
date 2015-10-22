using System;
using System.Linq.Expressions;
using WaterPoint.Data.Entity;

namespace WaterPoint.Core.Bll
{
    public interface ISqlBuilder
    {
        string GetSql();
    }

    public interface ISqlBuilder<T> : ISqlBuilder
    {
        void Analyze();
    }

    public interface ISelectSqlBuilder<T> : ISqlBuilder<T>
    {
        //void AddOrderBy<T>(Expression<Func<T, object>> orderby, bool desc);

        void AddOrderBy(string orderBy, bool desc);

        void AddOffset(int offset, int fetch);

        void AddConditions<T>(Expression<Func<T, bool>> values);
    }

    public interface ICreateSqlBuilder<T> : ISqlBuilder<T>
    {
        void AddValueParameters(IDataEntity input);
    }

    public interface IUpdateSqlBuilder<T> : ISqlBuilder<T>
    {
    }

    public interface IDeleteSqlBuilder<T> : ISqlBuilder<T>
    {
    }
}
