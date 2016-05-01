using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.CostItems;

namespace WaterPoint.Core.Bll.Commands.CostItems
{
    namespace WaterPoint.Core.Bll.Commands.Customers
    {
        public class BulkDeleteCostItemsCommand : ICommand<BulkDeleteCostItems>
        {
            public void BuildQuery(BulkDeleteCostItems parameter)
            {
                Query = "[dbo].[BulkDelete_CostItems]";

                Parameters = new
                {
                    organizationid = parameter.OrganizationId,
                    customerIds = parameter.CostItems
                };
            }

            public string Query { get; private set; }
            public object Parameters { get; private set; }
            public bool IsStoredProcedure => true;
        }
    }
}
