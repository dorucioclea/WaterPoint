using WaterPoint.Api.Common;
using WaterPoint.Core.Domain.QueryParameters.Jobs;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Payloads.Jobs;
using WaterPoint.Core.Domain.Requests.Jobs;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.Pocos.Jobs;

namespace WaterPoint.Core.RequestProcessor.Jobs
{
    public class UpdateJobProcessor
        : BaseUpdateProcessor<UpdateJobRequest, WriteJobPayload, UpdateJob, GetJob, JobWithDetailsPoco>
    {
        public UpdateJobProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IPatchEntityAdapter adapter,
            IQuery<GetJob> getQuery,
            IQueryRunner<GetJob, JobWithDetailsPoco> getRunner,
            ICommand<UpdateJob> updateQuery,
            ICommandExecutor<UpdateJob> updateExecutor)
            : base(dapperUnitOfWork, adapter, getQuery, getRunner, updateQuery, updateExecutor)
        {
        }

        public override GetJob BuildGetParameter(UpdateJobRequest input)
        {
            return new GetJob
            {
                OrganizationId = input.OrganizationId,
                JobId = input.Id
            };
        }
    }
}
