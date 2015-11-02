using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Remoting.Channels;
using WaterPoint.Data.Entity;
using WaterPoint.Data.Entity.Attributes;

namespace WaterPoint.Core.Bll
{
    public enum JoinTypes
    {
        InnerJoin,
        LeftJoin,
        RightJoin
    }

    public class SelectSqlBuilder : ISelectSqlBuilder
    {
        private string _fromSchema;
        private string _fromTable;
        private string _fromAlias;
        private string _totalCount = string.Empty;
        private string _where = string.Empty;
        private string _orderBy = string.Empty;
        private string _fetch = string.Empty;
        private string _template = string.Empty;
        private readonly List<string> _columns = new List<string>();
        private readonly List<string> _joins = new List<string>();

        public string Where { get { return _where; } }
        public string Columns { get { return string.Join(", \r\n", _columns); } }
        public string FromTable { get { return _fromTable; } }
        public string Joins { get { return string.Join("\r\n", _joins); } }
        public string OrderBy { get { return _orderBy; } }

        public void AddTemplate(string template)
        {
            _template = template;
        }

        //public void AddOrderBy<T>(Expression<Func<T, object>> orderby, bool desc)
        //{
        //    var orderClause = orderby.Body as NewExpression;

        //    if (orderClause == null)
        //        throw new ArgumentException("orderClause");

        //    var list = orderClause.Members.Select(i =>
        //        string.Format("{0}.{1}", _fromTable, i.Name));

        //    _orderBy = string.Join(",", list);

        //    if (desc && !string.IsNullOrWhiteSpace(_orderBy))
        //        _orderBy += " DESC ";
        //}

        public void AddOrderBy<T>(string orderBy, bool desc)
        {
            var index = typeof(T).GetProperties().ToList().FindIndex(i =>
                string.Equals(i.Name, orderBy, StringComparison.CurrentCultureIgnoreCase)) + 1;

            _orderBy = $"{index} {(desc ? "DESC" : string.Empty)} ";
        }

        //public void AddOffset(int offset, int fetch)
        //{
        //    var fetchClause = " OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY ";

        //    var totalCountClause = string.Format(@" CROSS APPLY(
        //                                SELECT COUNT(*) TotalCount FROM
        //                                {0}
        //                                {1}
        //                                )[Count] ", SqlPatterns.Table, SqlPatterns.Where);

        //    //Columns = string.Join(",", Columns, "[TotalCount]");

        //    _fetch = string.Format(fetchClause, offset, fetch);

        //    _totalCount = string.Format(totalCountClause, _fromTable);
        //}

        public string GetSql()
        {
            return _template
                .Replace(SqlPatterns.TotalCount, _totalCount)
                .Replace(SqlPatterns.FromTable, $"[{_fromSchema}].[{_fromTable}] {_fromAlias}")
                .Replace(SqlPatterns.Columns, Columns)
                .Replace(SqlPatterns.Where, _where)
                .Replace(SqlPatterns.OrderBy, _orderBy)
                .Replace(SqlPatterns.Fetch, _fetch);
        }

        public void AddConditions<T>(Expression<Func<T, bool>> values)
        {
            var whereClause = values.Body as BinaryExpression;

            var expressionConverter = new PredicateExpressionConverter();

            _where = expressionConverter.Convert(_fromAlias, whereClause);
        }

        public void AddManyToManyJoin<T>(JoinTypes jointype, string viaSchema, string viaTable, string viaAlias, string myColumn, string parentColumn)
        {
            string join;

            switch (jointype)
            {
                case JoinTypes.LeftJoin:
                    join = "LEFT JOIN";
                    break;

                case JoinTypes.RightJoin:
                    join = "RIGHT JOIN";
                    break;
                case JoinTypes.InnerJoin:
                    join = "INNER JOIN";
                    break;
                default:
                    throw new NotSupportedException("Join types");
            }

            var typePair = GetTable<T>();

            //e.g.LEFT JOIN dbo.CustomerAddress on dbo.CustomerAddress.customerId = customer.id
            _joins.Add($"{join} [{viaSchema}].[{viaTable}] {viaAlias} ON {viaAlias}.[{3}Id] = {_fromAlias}.[Id]");

            _joins.Add($"{join} [{typePair.Key.Schema}].[{typePair.Key.Table}] {typePair.Key.Alias}" +
                       $" ON {typePair.Key.Alias}.[Id] = {viaAlias}.[{typePair.Key.Table}Id]");
        }

        public void AddJoin<T>(JoinTypes jointype, string myColumn, string parentColumn)
        {
            string join;

            switch (jointype)
            {
                case JoinTypes.LeftJoin:
                    join = "LEFT JOIN";
                    break;

                case JoinTypes.RightJoin:
                    join = "RIGHT JOIN";
                    break;
                case JoinTypes.InnerJoin:
                    join = "INNER JOIN";
                    break;
                default:
                    throw new NotSupportedException("Join types");
            }

            var typePair = GetTable<T>();

            _joins.Add($"{join} [{typePair.Key.Schema}].[{typePair.Key.Table}] {typePair.Key.Alias}" +
                        $" ON {typePair.Key.Alias}.[{myColumn}] = {_fromAlias}.[{parentColumn}]");
        }

        public void AddForeignColumns<T>()
        {
            AnalyzeColumns<T>(true);
        }

        public void AddPrimaryColumns<T>()
        {
            AnalyzeColumns<T>(false);
        }

        #region private methods

        private void AnalyzeColumns<T>(bool isForeign)
        {
            var typePair = GetTable<T>();
            var tableAttribute = typePair.Key;
            var properties = typePair.Value;

            if (!isForeign)
            {
                _fromAlias = tableAttribute.Alias;
                _fromSchema = tableAttribute.Schema;
                _fromTable = tableAttribute.Table;
            }

            var columns = properties.Where(i => i.GetCustomAttribute(typeof(ForeignAttribute)) == null)
                .Select
                //main table columns e.g. [dbo].[Customer].[Id]
                //foreign table columns e.g. [dbo].[Address].[Street] AddressStreet
                (
                    i => string.Format("{0}.[{1}] {2}",
                        tableAttribute.Alias,
                        i.Name,
                        isForeign ? tableAttribute.Table + i.Name : string.Empty)
                );

            _columns.AddRange(columns);
        }

        private KeyValuePair<TableAttribute, IEnumerable<PropertyInfo>> GetTable<T>()
        {
            var type = typeof(T);

            var properties = type.GetProperties();

            var tableAttribute = type.GetCustomAttribute(typeof(TableAttribute)) as TableAttribute;

            if (tableAttribute == null)
                throw new InvalidDataException("Missing TableAttribute.");

            return new KeyValuePair<TableAttribute, IEnumerable<PropertyInfo>>(tableAttribute, properties);
        }

        #endregion
    }
}
