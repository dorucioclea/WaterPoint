using Utility;
using WaterPoint.Api.Common;
using WaterPoint.Core.Domain.QueryParameters.Customers;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.Domain.Contracts.Jobs;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Requests.Customers;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.Pocos.Jobs;

namespace WaterPoint.Core.RequestProcessor.Customers
{
    public class ListCustomerJobsProcessor :
        SimplePagedProcessor<ListCustomerJobsRequest, ListCustomerJobs, JobWithStatusPoco, JobWithStatusContract>
    {
        public ListCustomerJobsProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<ListCustomerJobs> listQuery,
            IPagedQueryRunner<ListCustomerJobs, JobWithStatusPoco> listQueryRunner)
            : base(dapperUnitOfWork, listQuery, listQueryRunner)
        {
        }

        public override JobWithStatusContract Map(JobWithStatusPoco source)
        {
            return JobMapper.Map(source);
        }
    }
}
