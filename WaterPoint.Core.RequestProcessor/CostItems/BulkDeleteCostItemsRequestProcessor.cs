using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.CostItems;
using WaterPoint.Core.Domain.Requests.CostItems;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.RequestProcessor.CostItems
{
    public class BulkDeleteCostItemsRequestProcessor :
        BaseDapperUowRequestProcess,
        IDeleteRequestProcessor<BulkDeleteCostItemsRequest>
    {
        private readonly ICommand<BulkDeleteCostItems> _deleteCommand;
        private readonly ICommandExecutor _deleteExecutor;

        public BulkDeleteCostItemsRequestProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<BulkDeleteCostItems> deleteCommand,
            ICommandExecutor deleteExecutor)
            : base(dapperUnitOfWork)
        {
            _deleteCommand = deleteCommand;
            _deleteExecutor = deleteExecutor;
        }

        public CommandResult Process(BulkDeleteCostItemsRequest input)
        {
            var result = UowProcess(Delete, input);

            return new DeleteCommandResult(result, result > 0);
        }

        private int Delete(BulkDeleteCostItemsRequest input)
        {
            var param = new BulkDeleteCostItems
            {
                OrganizationId = input.OrganizationId,
                CostItems = input.CostItems
            };

            _deleteCommand.BuildQuery(param);

            return _deleteExecutor.ExecuteNonQuery(_deleteCommand);
        }
    }
}
