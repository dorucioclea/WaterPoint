using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using WaterPoint.Data.Entity;
using WaterPoint.Data.Entity.Attributes;

namespace WaterPoint.Core.Bll
{
    public class SelectSqlBuilder<T> : SqlBuilder<T>, ISelectSqlBuilder<T>
           where T : IDataEntity
    {
        private string _totalCount = string.Empty;
        private string _where = string.Empty;
        private string _orderBy = string.Empty;
        private string _fetch = string.Empty;

        protected string Where { get; private set; }

        public void AddOrderBy<T>(Expression<Func<T, object>> orderby, bool desc)
        {
            var orderClause = orderby.Body as NewExpression;

            if (orderClause == null)
                throw new ArgumentException("orderClause");

            var list = orderClause.Members.Select(i =>
                 string.Format("{0}.{1}", ParentTable, i.Name));

            _orderBy = string.Join(",", list);

            if (desc && !string.IsNullOrWhiteSpace(_orderBy))
                _orderBy += " DESC ";
        }

        public void AddOrderBy(string orderBy, bool desc)
        {
            if (string.IsNullOrWhiteSpace(orderBy))
                return;

            var index = Properties.FindIndex(i =>
                string.Equals(i.Name, orderBy, StringComparison.CurrentCultureIgnoreCase)) + 1;

            _orderBy = string.Format("{0} {1} ", index, desc ? "DESC" : string.Empty);
        }

        public void AddOffset(int offset, int fetch)
        {
            var fetchClause = " OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY ";

            var totalCountClause = string.Format(@" CROSS APPLY(
                                        SELECT COUNT(*) TotalCount FROM
                                        {0}
                                        {1}
                                        )[Count] ", Keywords.Table, Keywords.Where);

            Columns = string.Join(",", Columns, "[TotalCount]");

            _fetch = string.Format(fetchClause, offset, fetch);

            _totalCount = string.Format(totalCountClause, ParentTable);
        }

        public string GetSql()
        {
            var sql = string.Format(@"
                SELECT {0}
                FROM {1}
                {2}
                {3}
                {4}
                {5}", Keywords.Columns, Keywords.Table, Keywords.TotalCount, Keywords.Where, Keywords.OrderBy, Keywords.Fetch);


            _where = !string.IsNullOrWhiteSpace(_where) ? "WHERE " + _where : string.Empty;
            _fetch = !string.IsNullOrWhiteSpace(_fetch) ? _fetch : string.Empty;
            _totalCount = !string.IsNullOrWhiteSpace(_totalCount) ? _totalCount : string.Empty;

            if (string.IsNullOrWhiteSpace(_orderBy) && !string.IsNullOrWhiteSpace(_fetch))
            {
                var primary = Properties.FirstOrDefault(i => i.GetCustomAttribute(typeof(PrimaryAttribute)) != null);

                if (primary == null)
                    throw new InvalidOperationException("Pagination requires primary key");

                _orderBy = (Properties.FindIndex(i => i == primary) + 1).ToString();
            }

            _orderBy = !string.IsNullOrWhiteSpace(_orderBy) ? " ORDER BY " + _orderBy : string.Empty;


            return sql.Replace(Keywords.TotalCount, _totalCount)
                .Replace(Keywords.Table, ParentTable)
                .Replace(Keywords.Columns, Columns)
                .Replace(Keywords.Where, _where)
                .Replace(Keywords.OrderBy, _orderBy)
                .Replace(Keywords.Fetch, _fetch);
        }

        public void AddConditions<T>(Expression<Func<T, bool>> values)
        {
            var whereClause = values.Body as BinaryExpression;

            var expressionConverter = new PredicateExpressionConverter();

            _where = expressionConverter.Convert(ParentTable, whereClause);
        }

        public void Analyze()
        {
            //where it's not a foreign key properties
            var properties = Type.GetProperties();

            Columns = string.Join(",\r\n", properties.Select(i => string.Format("{0}.[{1}]", ParentTable, i.Name)));
        }
    }
}
