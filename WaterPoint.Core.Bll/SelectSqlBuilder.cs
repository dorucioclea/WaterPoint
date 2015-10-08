using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.Entity;
using WaterPoint.Data.Entity.Attributes;

namespace WaterPoint.Core.Bll
{
    public class SelectSqlBuilder<T> : ISqlBuilder<T>
           where T : IDataEntity
    {
        private string _select;
        private string _where;
        private readonly string _parentTable;
        private readonly Type _type;

        public SelectSqlBuilder()
        {
            _type = typeof(T);

            var tableAttribute = _type.GetCustomAttribute(typeof(TableAttribute)) as TableAttribute;

            if (tableAttribute == null)
                throw new InvalidDataException("Missing TableAttribute decoration.");

            _parentTable = $"[{tableAttribute.Schema}].[{tableAttribute.Table}]";
        }

        public string GetSql()
        {
            return $"{_select} {_where}";
        }

        public ISqlBuilder<T> Analyze()
        {
            //where it's not a foreign key properties
            var properties = _type.GetProperties(); //.Where(i=>i.getcu);

            var columns = string.Join(",", properties.Select(i => $"{_parentTable}.[{i.Name}]"));

            var select = $@"
                SELECT {columns}
                FROM {_parentTable}";
            _select = select;

            return this;
        }

        public ISqlBuilder<T> AddWhere<T>(Expression<Func<T, bool>> where)
        {
            var whereClause = where.Body as BinaryExpression;

            var expressionConverter = new PredicateExpressionConverter();

            var result = expressionConverter.Convert(_parentTable, whereClause);

            _where = $" WHERE {result} ";

            return this as ISqlBuilder<T>;
        }
    }
}
