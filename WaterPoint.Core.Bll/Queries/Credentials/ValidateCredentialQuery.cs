using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.Pocos.Views;

namespace WaterPoint.Core.Bll.Queries.Credentials
{
    public class ValidateCredentialQuery : IQuery
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        private readonly string _sqlTemplate = $@"
                SELECT
                    {SqlPatterns.Columns}
                FROM
                    {SqlPatterns.FromTable}
                WHERE
                   {SqlPatterns.Where}";

        public ValidateCredentialQuery(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(string email, string password)
        {
            var builder = _sqlBuilderFactory.Create<SelectSqlBuilder>();

            builder.AddTemplate(_sqlTemplate);
            builder.AddColumns<ValidCredential>();
            builder.AddConditions<ValidCredential>(i => i.Email == email && i.Password == password);

            var sql = builder.GetSql();

            Query = sql;

            Parameters = new
            {
                email,
                password
            };
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
