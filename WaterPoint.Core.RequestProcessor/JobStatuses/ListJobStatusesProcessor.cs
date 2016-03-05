using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.JobStatuses;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters;
using WaterPoint.Core.Domain.Requests;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.JobStatuses
{
    public class ListJobStatusesProcessor
        : BaseDapperUowRequestProcess,
        IListProcessor<ListOrgEntitiesRequest, JobStatusContract>
    {
        private readonly IQuery<ListOrgEntities, JobStatus> _query;
        private readonly IQueryListRunner _runner;

        public ListJobStatusesProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<ListOrgEntities, JobStatus> query,
            IQueryListRunner runner)
            : base(dapperUnitOfWork)
        {
            _query = query;
            _runner = runner;
        }

        public IEnumerable<JobStatusContract> Process(ListOrgEntitiesRequest input)
        {
            _query.BuildQuery(new ListOrgEntities
            {
                OrganizationId = input.OrganizationId
            });

            var result = _runner.Run(_query);

            return result.Select(JobStatusesMapper.Map);
        }
    }
}
