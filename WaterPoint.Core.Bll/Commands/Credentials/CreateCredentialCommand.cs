using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Credentials;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Commands.Credentials
{
    public class CreateCredentialCommand : ICommand<CreateCredential>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        public CreateCredentialCommand(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(CreateCredential input)
        {
            var builder = _sqlBuilderFactory.Create<CreateSqlBuilder<Credential>>();

            builder.Analyze<CreateCredential>();
            builder.AddValueParameters(input);

            var sql = builder.GetSql();

            Query = sql;
            Parameters = builder.Parameters;
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
        public bool IsStoredProcedure => false;
    }
}
