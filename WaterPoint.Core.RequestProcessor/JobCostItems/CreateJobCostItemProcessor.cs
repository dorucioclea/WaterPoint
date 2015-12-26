﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Contracts.Jobs;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.JobCostItems;
using WaterPoint.Core.Domain.QueryParameters.Jobs;
using WaterPoint.Core.Domain.QueryParameters.JobTasks;
using WaterPoint.Core.Domain.Requests.JobCostItems;
using WaterPoint.Core.Domain.Requests.Jobs;
using WaterPoint.Core.Domain.Requests.JobTasks;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.RequestProcessor.JobCostItems
{
    public class CreateJobCostItemProcessor : BaseDapperUowRequestProcess,
        IRequestProcessor<CreateJobCostItemRequest, CommandResultContract>
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

        public CommandResultContract Process(CreateJobCostItemRequest input)
        {
            var result = UowProcess(ProcessDeFacto, input);

            return result;
        }

        public CreateJobCostItem AnalyzeParameter(CreateJobCostItemRequest input)
        {
            return new CreateJobCostItem
            {
                JobId = input.Parameter.JobId,
                IsBillable = input.Payload.IsBillable,
                LongDescription = input.Payload.LongDescription,
                ShortDescription = input.Payload.ShortDescription,
                Code = input.Payload.Code,
                CostItemId = input.Payload.CostItemId,
                Quantity = input.Payload.Quantity,
                UnitCost = input.Payload.UnitCost,
                UnitPrice = input.Payload.UnitPrice
            };
        }

        private CommandResultContract ProcessDeFacto(CreateJobCostItemRequest input)
        {
            _command.BuildQuery(AnalyzeParameter(input));

            var newId = _executor.Execute(_command);

            if (newId > 0)
                return new CommandResultContract
                {
                    Data = newId,
                    Message = $"job task {newId} has been created",
                    Status = CommandResultContract.Success
                };

            return new CommandResultContract
            {
                Data = null,
                Message = "operation is finished but there is no result returned",
                Status = CommandResultContract.Failed
            };
        }
    }
}
