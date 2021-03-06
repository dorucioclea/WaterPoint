﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity;
using WaterPoint.Data.Entity.Attributes;

namespace WaterPoint.Core.Bll
{
    public class UpdateSqlBuilder<T> : SqlBuilder<T>, ICreateSqlBuilder
           where T : IDataEntity
    {
        private string _where = string.Empty;

        public Dictionary<string, object> Parameters { get; private set; }

        public string Where
        {
            get { return _where; }
        }

        private readonly IEnumerable<PropertyInfo> _propertyInfos;

        public UpdateSqlBuilder()
        {
            _propertyInfos = Type.GetProperties();
        }

        public string GetSql()
        {
            var sql = $@"
                UPDATE {SqlPatterns.FromTable}
                SET {SqlPatterns.Columns}
                WHERE {SqlPatterns.Where}";

            return sql
                .Replace(SqlPatterns.FromTable, ParentTable)
                .Replace(SqlPatterns.Columns, Columns)
                .Replace(SqlPatterns.Where, _where);
        }

        public void Analyze(IQueryParameter input)
        {
            var columns =
                input.GetType().GetProperties()
                .Where(i => !SqlBuilderHelper.ShouldIgnore(i, IgnoreTypes));

            Columns = string.Join(
                ",\r\n",
                columns.Select(i => $@"{ParentTable}.[{i.Name}] = @{i.Name.ToLower()}")
                );
        }

        public void AddValueParameters(IQueryParameter input)
        {
            var inputProperties = input.GetType().GetProperties().ToArray();

            if (Parameters == null)
                Parameters = new Dictionary<string, object>();

            foreach (var propertyInfo in _propertyInfos)
            {
                var inputPro = inputProperties.FirstOrDefault(i => string.Equals(i.Name, propertyInfo.Name, StringComparison.CurrentCultureIgnoreCase));

                if (inputPro == null)
                    continue;

                var value = inputPro.GetValue(input, null);

                var name = propertyInfo.Name.ToLower();

                Parameters.Add(name, value);
            }

        }

        public void AddParamter(string key, object value)
        {
            if (Parameters == null)
                Parameters = new Dictionary<string, object>();

            Parameters.Add(key, value);
        }

        public void AddConditions<TCondition>(Expression<Func<TCondition, bool>> values)
        {
            var whereClause = values.Body as BinaryExpression;

            var expressionConverter = new PredicateExpressionConverter();

            _where = expressionConverter.Convert(ParentTable, whereClause);
        }

        private IEnumerable<Type> IgnoreTypes
        {
            get
            {
                return new[]
                {
                    typeof (PrimaryAttribute),
                    typeof (IgnoreWhenUpdateAttribute),
                    typeof (ManyToManyAttribute),
                    typeof (OneToManyAttribute),
                    typeof (ComputedAttribute),
                    typeof (TableAttribute)
                };
            }
        }
    }
}
