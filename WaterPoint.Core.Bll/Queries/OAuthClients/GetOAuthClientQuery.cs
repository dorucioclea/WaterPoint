using WaterPoint.Core.Bll.QueryParameters.Credentials;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Queries.OAuthClients
{
    public class GetOAuthClientQuery : IQuery<GetAuthClient>
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

        public void BuildQuery(GetAuthClient parameter)
        {
            var builder = _sqlBuilderFactory.Create<SelectSqlBuilder>();

            builder.AddTemplate(_sqlTemplate);
            builder.AddColumns<OAuthClient>();
            builder.AddConditions<OAuthClient>(
                i => i.ClientId == parameter.ClientId
                && i.ClientSecret == parameter.ClientSecret
                && i.IsInternal == parameter.IsInternal);

            var sql = builder.GetSql();

            Query = sql;

            Parameters = new
            {
                clientId = parameter.ClientId,
                clientSecret = parameter.ClientSecret,
                isInternal = parameter.IsInternal
            };
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
