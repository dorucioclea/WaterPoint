using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Addresses;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Commands.Addresses
{
    public class CreateAddressCommand : ICommand<CreateAddress>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        public CreateAddressCommand(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(CreateAddress input)
        {
            var builder = _sqlBuilderFactory.Create<CreateSqlBuilder<Address>>();

            builder.Analyze<CreateAddress>();
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
