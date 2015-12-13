using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Queries.OAuthClients
{
    public class GetOAuthClientQuery : IQuery
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        private readonly string _sqlTemplate = $@"
                SELECT
                    {SqlPatterns.Columns}
                FROM
                    {SqlPatterns.FromTable}
                WHERE
                   {SqlPatterns.Where}";

        public GetOAuthClientQuery(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(string clientId, string clientSecret, bool isInternal)
        {
            var builder = _sqlBuilderFactory.Create<SelectSqlBuilder>();

            builder.AddTemplate(_sqlTemplate);
            builder.AddPrimaryColumns<OAuthClient>();
            builder.AddConditions<OAuthClient>(
                i => i.ClientId == clientId && i.ClientSecret == clientSecret && i.IsInternal == isInternal);

            var sql = builder.GetSql();

            Query = sql;

            Parameters = new
            {
                clientId,
                clientSecret,
                isInternal
            };
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
