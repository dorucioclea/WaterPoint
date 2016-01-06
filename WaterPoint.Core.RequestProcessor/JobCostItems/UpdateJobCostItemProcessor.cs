using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;
using WaterPoint.Api.Common;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Payloads.JobCostItems;
using WaterPoint.Core.Domain.QueryParameters.JobCostItems;
using WaterPoint.Core.Domain.Requests.JobCostItems;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.JobCostItems
{
    public class UpdateJobCostItemProcessor :
        BaseDapperUowRequestProcess,
        IWriteRequestProcessor<UpdateJobCostItemRequest>
    {
        private readonly IPatchEntityAdapter _patchEntityAdapter;
        private readonly IQuery<GetJobCostItem> _getJobCostItemByIdQuery;
        private readonly IQueryRunner<GetJobCostItem, JobCostItem> _getJobCostItemByIdQueryRunner;
        private readonly ICommand<UpdateJobCostItem> _updateJobCostItemByIdQuery;
        private readonly ICommandExecutor<UpdateJobCostItem> _updateCommandExecutor;

        public UpdateJobCostItemProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IPatchEntityAdapter patchEntityAdapter,
            IQuery<GetJobCostItem> getJobCostItemByIdQuery,
            IQueryRunner<GetJobCostItem, JobCostItem> getJobCostItemByIdQueryRunner,
            ICommand<UpdateJobCostItem> updateJobCostItemByIdQuery,
            ICommandExecutor<UpdateJobCostItem> updateCommandExecutor)
            : base(dapperUnitOfWork)
        {
            _patchEntityAdapter = patchEntityAdapter;
            _getJobCostItemByIdQuery = getJobCostItemByIdQuery;
            _getJobCostItemByIdQueryRunner = getJobCostItemByIdQueryRunner;
            _updateJobCostItemByIdQuery = updateJobCostItemByIdQuery;
            _updateCommandExecutor = updateCommandExecutor;
        }

        public CommandResult Process(UpdateJobCostItemRequest input)
        {
            var result = UowProcess(ProcessDeFacto, input);

            return new CommandResult(result, result > 0);
        }

        private int ProcessDeFacto(UpdateJobCostItemRequest input)
        {
            var getJobCostItemParam = new GetJobCostItem
            {
                Id = input.Id,
                JobId = input.JobId,
                OrganizationId = input.OrganizationId
            };

            _getJobCostItemByIdQuery.BuildQuery(getJobCostItemParam);

            var existingJobCostItem = _getJobCostItemByIdQueryRunner.Run(_getJobCostItemByIdQuery);

            var updatedJobCostItem =
                _patchEntityAdapter.PatchEnitity<WriteJobCostItemPayload, JobCostItem, UpdateJobCostItem>
                (
                    existingJobCostItem,
                    input.Payload.Patch
                );

            //then build the query to update the object.
            _updateJobCostItemByIdQuery.BuildQuery(updatedJobCostItem);

            return _updateCommandExecutor.Execute(_updateJobCostItemByIdQuery);
        }
    }
}
