using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using WaterPoint.Data.Entity;
using WaterPoint.Data.Entity.Attributes;

namespace WaterPoint.Core.Bll
{
    public class SelectSqlBuilder<T> : ISelectSqlBuilder<T>
           where T : IDataEntity
    {
        private string _columns;
        private string _totalCount = string.Empty;
        private string _where = string.Empty;
        private string _orderBy = string.Empty;
        private string _fetch = string.Empty;
        private readonly string _parentTable;
        private readonly Type _type;

        private const string
            Columns = "/**COLUMNS**/",
            Table = "/**TABLE**/",
            TotalCount = "/**TOTALCOUNT**/",
            Where = "/**WHERE**/",
            OrderBy = "/**ORDERBY**/",
            Fetch = "/**FETCH**/",
            Join = "/**JOIN**/";


        public SelectSqlBuilder()
        {
            _type = typeof(T);

            var tableAttribute = _type.GetCustomAttribute(typeof(TableAttribute)) as TableAttribute;

            if (tableAttribute == null)
                throw new InvalidDataException("Missing TableAttribute decoration.");

            _parentTable = string.Format("[{0}].[{1}]", tableAttribute.Schema, tableAttribute.Table);
        }

        public void AddOrderBy<T>(Expression<Func<T, object>> orderby, bool desc)
        {
            var orderClause = orderby.Body as NewExpression;

            if (orderClause == null)
                throw new ArgumentException("orderClause");

            var list = orderClause.Members.Select(i =>
                 string.Format("{0}.{1}", _parentTable, i.Name));

            _orderBy = string.Join(",", list);

            if (desc && !string.IsNullOrWhiteSpace(_orderBy))
                _orderBy += " DESC ";
        }

        public void AddOrderBy(string orderBy, bool desc)
        {
            var properties = _type.GetProperties().ToList();

            int index;

            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                index = properties.FindIndex(i => i.Name.ToLower() == orderBy.ToLower()) + 1;
            }
            else
            {
                var primary = properties.FirstOrDefault(i => i.GetCustomAttribute(typeof(PrimaryAttribute)) != null);

                index = primary == null ? 0 : properties.FindIndex(i => i == primary);
            }

            if (index != 0)
                _orderBy = string.Format("{0} {1}", index, desc ? "DESC" : string.Empty);
        }

        public void AddOffset(int offset, int fetch)
        {
            var fetchClause = " OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY ";

            var totalCountClause = string.Format(@" CROSS APPLY(
                                        SELECT COUNT(*) TotalCount FROM
                                        {0}
                                        {1}
                                        )[Count] ", Table, Where);

            _columns = string.Join(",", _columns, "[TotalCount]");

            _fetch = string.Format(fetchClause, offset, fetch);

            _totalCount = string.Format(totalCountClause, _parentTable);
        }

        public string GetSql()
        {
            var sql = string.Format(@"
                SELECT {0}
                FROM {1}
                {2}
                {3}
                {4}
                {5}", Columns, Table, TotalCount, Where, OrderBy, Fetch);


            _where = !string.IsNullOrWhiteSpace(_where) ? "WHERE " + _where : string.Empty;
            _orderBy = !string.IsNullOrWhiteSpace(_orderBy) ? " ORDER BY " + _orderBy : string.Empty;
            _fetch = !string.IsNullOrWhiteSpace(_fetch) ? _fetch : string.Empty;
            _totalCount = !string.IsNullOrWhiteSpace(_totalCount) ? _totalCount : string.Empty;

            return sql.Replace(TotalCount, _totalCount)
                .Replace(Table, _parentTable)
                .Replace(Columns, _columns)
                .Replace(Where, _where)
                .Replace(OrderBy, _orderBy)
                .Replace(Fetch, _fetch);
        }

        public void Analyze()
        {
            //where it's not a foreign key properties
            var properties = _type.GetProperties();

            _columns = string.Join(",\r\n", properties.Select(i => string.Format("{0}.[{1}]", _parentTable, i.Name)));
        }

        public void AddWhere<T>(Expression<Func<T, bool>> where)
        {
            var whereClause = where.Body as BinaryExpression;

            var expressionConverter = new PredicateExpressionConverter();

            _where = expressionConverter.Convert(_parentTable, whereClause);
        }
    }
}
