using WaterPoint.Core.Domain.QueryParameters.Credentials;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity.Pocos.Views;

namespace WaterPoint.Core.Bll.Queries.Credentials
{
    public class ListValidateCredentialsQuery : IQuery<ListCredentials, ValidCredential>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        private readonly string _sqlTemplate = $@"
                SELECT
                    {SqlPatterns.Columns}
                FROM
                    {SqlPatterns.FromTable}
                WHERE
                   {SqlPatterns.Where}
                ";

        public ListValidateCredentialsQuery(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(ListCredentials parameter)
        {
            var builder = _sqlBuilderFactory.Create<SelectSqlBuilder>();

            builder.AddTemplate(_sqlTemplate);
            builder.AddColumns<ValidCredential>();
            builder.AddConditions<ValidCredential>(i => i.Email == parameter.Email && i.Password == parameter.Password);

            var sql = builder.GetSql();

            Query = sql;

            Parameters = new
            {
                email = parameter.Email,
                password = parameter.Password
            };
        }

        public bool IsStoredProcedure => false;
        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
