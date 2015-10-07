using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.Entity;

namespace WaterPoint.Core.Bll
{
    public interface ISqlBuilder
    {
        string GetSql();

        string GetSql<T>(Expression<Func<T, object>> parameters) where T : IDataEntity;
    }
}
