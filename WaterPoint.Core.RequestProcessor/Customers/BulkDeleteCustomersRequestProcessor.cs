using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Customers;
using WaterPoint.Core.Domain.Requests.Customers;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.RequestProcessor.Customers
{
    public class BulkDeleteCustomersRequestProcessor :
        BaseDapperUowRequestProcess,
        IDeleteRequestProcessor<BulkDeleteCustomersRequest>
    {
        private readonly ICommand<BulkDeleteCustomer> _deleteCommand;
        private readonly ICommandExecutor _deleteExecutor;

        public BulkDeleteCustomersRequestProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<BulkDeleteCustomer> deleteCommand,
            ICommandExecutor deleteExecutor)
            : base(dapperUnitOfWork)
        {
            _deleteCommand = deleteCommand;
            _deleteExecutor = deleteExecutor;
        }

        public CommandResult Process(BulkDeleteCustomersRequest input)
        {
            var result = UowProcess(Delete, input);

            return new DeleteCommandResult(result, result > 0);
        }

        private int Delete(BulkDeleteCustomersRequest input)
        {
            var param = new BulkDeleteCustomer
            {
                OrganizationId = input.OrganizationId,
                Customers = input.Customers
            };

            _deleteCommand.BuildQuery(param);

            return _deleteExecutor.ExecuteNonQuery(_deleteCommand);
        }
    }
}
