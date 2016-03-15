using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Invoices;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Commands.Invoices
{
    public class UpdateInvoiceCommand : ICommand<UpdateInvoice>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

    public UpdateInvoiceCommand(ISqlBuilderFactory sqlBuilderFactory)
    {
        _sqlBuilderFactory = sqlBuilderFactory;
    }

    public void BuildQuery(UpdateInvoice parameter)
    {
        var builder = _sqlBuilderFactory.Create<UpdateSqlBuilder<Invoice>>();

        builder.Analyze(parameter);
        builder.AddValueParameters(parameter);

        builder.AddConditions<Invoice>(i => i.OrganizationId == parameter.OrganizationId && i.Id == parameter.Id);

        var sql = builder.GetSql();

        Query = sql;

        Parameters = builder.Parameters;
    }

    public string Query { get; private set; }
    public object Parameters { get; private set; }
    public bool IsStoredProcedure => false;
}
}
