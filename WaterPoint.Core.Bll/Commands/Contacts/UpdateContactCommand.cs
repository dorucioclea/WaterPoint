using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Contacts;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Commands.Contacts
{
    public class UpdateContactCommand : ICommand<UpdateContact>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        public UpdateContactCommand(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(UpdateContact parameter)
        {
            var builder = _sqlBuilderFactory.Create<UpdateSqlBuilder<Contact>>();

            builder.Analyze(parameter);
            builder.AddValueParameters(parameter);

            builder.AddConditions<Contact>(i =>
                i.OrganizationId == parameter.OrganizationId && i.Id == parameter.Id);

            var sql = builder.GetSql();

            Query = sql;

            Parameters = builder.Parameters;
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
        public bool IsStoredProcedure => false;
    }
}
