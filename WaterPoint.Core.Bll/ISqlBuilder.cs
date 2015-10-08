using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.Entity;

namespace WaterPoint.Core.Bll
{
    public interface ISqlBuilder<T>
    {
        ISqlBuilder<T> Analyze();

        ISqlBuilder<T> AddWhere<T>(Expression<Func<T, bool>> where);

        string GetSql();
    }
}
