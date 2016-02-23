using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Addresses;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Commands.Addresses
{
    public class UpdateAddressCommand : ICommand<UpdateAddress>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        public UpdateAddressCommand(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(UpdateAddress parameter)
        {
            var builder = _sqlBuilderFactory.Create<UpdateSqlBuilder<Address>>();

            builder.Analyze(parameter);
            builder.AddValueParameters(parameter);

            builder.AddConditions<Address>(i =>
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
