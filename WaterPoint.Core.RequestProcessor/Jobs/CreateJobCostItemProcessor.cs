using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Jobs;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Jobs;
using WaterPoint.Core.Domain.Requests.Jobs;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.RequestProcessor.Jobs
{
    public class CreateJobCostItemProcessor: IRequestProcessor<CreateJobCostItemRequest, JobCostItemContract>
    {
        private readonly IDapperUnitOfWork _dapperUnitOfWork;
        private readonly ICommand<CreateJobCostItem> _command;
        private readonly ICommandExecutor<CreateJobCostItem> _executor;

        public CreateJobCostItemProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<CreateJobCostItem> command,
            ICommandExecutor<CreateJobCostItem> executor)
        {
            _dapperUnitOfWork = dapperUnitOfWork;
            _command = command;
            _executor = executor;
        }

        public JobCostItemContract Process(CreateJobCostItemRequest input)
        {
            throw new NotImplementedException();
        }
    }
}
