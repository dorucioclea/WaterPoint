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
        private readonly JobStatusQueryParameterConverter _jobqueryConverter;

        public ListJobsProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<PagedJobs> query,
            IPagedQueryRunner<PagedJobs, JobWithCustomerAndStatusPoco> runner,
            PaginationParameterConverter converter,
            JobStatusQueryParameterConverter jobqueryConverter)
            : base(dapperUnitOfWork, query, runner, converter)
        {
            _jobqueryConverter = jobqueryConverter;
        }

        public override JobWithCustomerContract Map(JobWithCustomerAndStatusPoco source)
        {
            return JobMapper.Map(source);
        }

        public override PagedJobs GetParameter(ListJobsRequest input)
        {

            var parameter = new PagedJobs
            {
                OrganizationId = input.OrganizationId
            };

            Converter.Convert(input, "Id")
                .MapTo(parameter);

            _jobqueryConverter.Convert(input)
                .MapTo(parameter);

            return parameter;
        }
    }
}
