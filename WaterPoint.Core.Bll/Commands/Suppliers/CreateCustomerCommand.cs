using WaterPoint.Core.Domain.QueryParameters.Suppliers;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Commands.Suppliers
{
    public class CreateSupplierCommand : ICommand<CreateSupplier>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        public CreateSupplierCommand(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(CreateSupplier input)
        {
            var builder = _sqlBuilderFactory.Create<CreateSqlBuilder<Supplier>>();

            builder.Analyze<CreateSupplier>();
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
