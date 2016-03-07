using System;
using System.Linq;
using WaterPoint.Api.Common;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.QueryParameters.Customers;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Payloads.Customers;
using WaterPoint.Core.Domain.Requests.Customers;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.Customers
{
    public class DeleteCustomerProcessor :
        BaseDapperUowRequestProcess,
        IWriteRequestProcessor<DeleteCustomersRequest>
    {
        private readonly ICommand<DeleteCustomer> _deleteCommand;
        private readonly ICommandExecutor _deleteExecutor;

        public DeleteCustomerProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<DeleteCustomer> deleteCommand,
            ICommandExecutor deleteExecutor)
            : base(dapperUnitOfWork)
        {
            _deleteCommand = deleteCommand;
            _deleteExecutor = deleteExecutor;
        }

        public CommandResult Process(DeleteCustomersRequest input)
        {
            var result = UowProcess(Delete, input);

            return new DeleteCommandResult(result, result > 0);
        }

        private int Delete(DeleteCustomersRequest input)
        {
            var param = new DeleteCustomer
            {
                Customers = input.Customers,
                OrganizationId = input.OrganizationId
            };

            _deleteCommand.BuildQuery(param);

            return _deleteExecutor.ExecuteNonQuery(_deleteCommand);
        }
    }
}
