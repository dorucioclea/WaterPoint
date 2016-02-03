using System.Collections.Generic;
using System.Linq;
using Utility;
using WaterPoint.Api.Common;
using WaterPoint.Core.Domain.QueryParameters.Jobs;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Jobs;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Requests.Jobs;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.Pocos.Jobs;

namespace WaterPoint.Core.RequestProcessor.Jobs
{
    public class ListJobsProcessor :
        PagedProcessor<ListJobsRequest, PagedJobs, JobWithCustomerAndStatusPoco, JobWithCustomerContract>
    {
        public ListJobsProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<PagedJobs, JobWithCustomerAndStatusPoco> query,
            IPagedQueryRunner runner)
            : base(dapperUnitOfWork, query, runner)
        {
        }

        public override JobWithCustomerContract Map(JobWithCustomerAndStatusPoco source)
        {
            return JobMapper.Map(source);
        }
    }
}
