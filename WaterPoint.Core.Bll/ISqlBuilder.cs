using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Castle.Components.DictionaryAdapter;
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

        void AddWhere<T>(Expression<Func<T, bool>> where);
    }

    public interface ISelectSqlBuilder<T> : ISqlBuilder<T>
    {
        //void AddOrderBy<T>(Expression<Func<T, object>> orderby, bool desc);

        void AddOrderBy(string orderBy, bool desc);

        void AddOffset(int offset, int fetch);
    }
}
