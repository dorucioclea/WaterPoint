﻿using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters;
using WaterPoint.Core.Domain.Requests;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.RequestProcessor.CostItems
{
    public class DeleteCostItemProcessor
        : BaseDapperUowRequestProcess,
        IDeleteRequestProcessor<OrganizationEntityRequest>
    {
        private readonly ICommand<ToggleIsDelete> _deleteCommand;
        private readonly ICommandExecutor _deleteExecutor;

        public DeleteCostItemProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<ToggleIsDelete> deleteCommand,
            ICommandExecutor deleteExecutor)
            : base(dapperUnitOfWork)
        {
            _deleteCommand = deleteCommand;
            _deleteExecutor = deleteExecutor;
        }

        public CommandResult Process(OrganizationEntityRequest input)
        {
            var result = UowProcess(Delete, input);

            return new DeleteCommandResult(result, result > 0);
        }

        private int Delete(OrganizationEntityRequest input)
        {
            var param = new ToggleIsDelete
            {
                Id = input.Id,
                IsDelete = true,
                OrganizationId = input.OrganizationId
            };

            _deleteCommand.BuildQuery(param);

            return _deleteExecutor.ExecuteNonQuery(_deleteCommand);
        }
    }
}
