using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Contacts;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Commands.Contacts
{
    public class CreateContactContactCommand : ICommand<CreateContact>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        public CreateContactContactCommand(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(CreateContact input)
        {
            var builder = _sqlBuilderFactory.Create<CreateSqlBuilder<Contact>>();

            builder.Analyze<CreateContact>();
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
