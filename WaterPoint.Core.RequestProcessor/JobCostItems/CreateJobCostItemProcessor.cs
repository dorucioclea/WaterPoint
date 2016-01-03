﻿using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.JobCostItems;
using WaterPoint.Core.Domain.Requests.JobCostItems;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.RequestProcessor.JobCostItems
{
    public class CreateJobCostItemProcessor : BaseDapperUowRequestProcess,
        IWriteRequestProcessor<CreateJobCostItemRequest>
    {
        private readonly IDapperUnitOfWork _dapperUnitOfWork;
        private readonly ICommand<CreateJobCostItem> _command;
        private readonly ICommandExecutor<CreateJobCostItem> _executor;

        public CreateJobCostItemProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<CreateJobCostItem> command,
            ICommandExecutor<CreateJobCostItem> executor)
            : base(dapperUnitOfWork)
        {
            _dapperUnitOfWork = dapperUnitOfWork;
            _command = command;
            _executor = executor;
        }

        public CommandResult Process(CreateJobCostItemRequest input)
        {
            var result = UowProcess(ProcessDeFacto, input);

            return new CommandResult(result, "job cost item", result > 0);
        }

        public CreateJobCostItem AnalyzeParameter(CreateJobCostItemRequest input)
        {
            return new CreateJobCostItem
            {
                JobId = input.JobId,
                IsBillable = input.Payload.IsBillable.Value,
                LongDescription = input.Payload.LongDescription,
                ShortDescription = input.Payload.ShortDescription,
                Code = input.Payload.Code,
                CostItemId = input.Payload.CostItemId,
                Quantity = input.Payload.Quantity,
                UnitCost = input.Payload.UnitCost.Value,
                UnitPrice = input.Payload.UnitPrice.Value
            };
        }

        private int ProcessDeFacto(CreateJobCostItemRequest input)
        {
            _command.BuildQuery(AnalyzeParameter(input));

            return _executor.Execute(_command);
        }
    }
}
