using System;
using System.Linq.Expressions;
using WaterPoint.Data.Entity;

namespace WaterPoint.Core.Bll
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
