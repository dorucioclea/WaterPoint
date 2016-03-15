using System;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Contacts;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Queries.Contacts
{
    public class ListContactsQuery : IQuery<ListContacts, Contact>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        private readonly string _sqlTemplate = $@"
                SELECT
                    {SqlPatterns.Columns}
                    ,[TotalCount]
                FROM
                    {SqlPatterns.FromTable}
                    CROSS APPLY(
                        SELECT COUNT(*) TotalCount
                        FROM
                            {SqlPatterns.FromTable}
                        WHERE
                            {SqlPatterns.Where}
                    )[Count]
                WHERE
                    {SqlPatterns.Where}
                ORDER BY {SqlPatterns.OrderBy}
                OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY  ";

        public ListContactsQuery(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(ListContacts parameter)
        {
            var builder = _sqlBuilderFactory.Create<SelectSqlBuilder>();

            builder.AddTemplate(_sqlTemplate);

            builder.AddColumns<Contact>();

            builder.AddConditions<Contact>(
                i => i.OrganizationId == parameter.OrganizationId
                    && i.IsDeleted == parameter.IsDeleted);

            builder.AddOrderBy<Contact>(parameter.Sort, parameter.IsDesc);

            builder.AddContains<Contact>(parameter.SearchTerm);

            var sql = builder.GetSql();

            Query = sql;

            Parameters = new
            {
                organizationId = parameter.OrganizationId,
                offset = parameter.Offset,
                pageSize = parameter.PageSize,
                searchTerm = parameter.SearchTerm,
                isdeleted = parameter.IsDeleted
            };
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
        public bool IsStoredProcedure => false;
    }
}
