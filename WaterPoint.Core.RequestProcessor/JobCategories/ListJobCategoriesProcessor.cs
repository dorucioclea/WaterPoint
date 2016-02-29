using System.Collections.Generic;
using System.Linq;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.JobCategories;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.JobCategories;
using WaterPoint.Core.Domain.Requests.JobCategories;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.JobCategories
{
    public class ListJobCategoriesProcessor :
        BaseDapperUowRequestProcess,
        IListProcessor<ListJobCategoriesRequest, JobCategoryContract>
    {
        private readonly IQuery<ListJobCategories, JobCategory> _query;
        private readonly IQueryListRunner _runner;

        public ListJobCategoriesProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<ListJobCategories, JobCategory> query,
            IQueryListRunner runner)
            : base(dapperUnitOfWork)
        {
            _query = query;
            _runner = runner;
        }

        public IEnumerable<JobCategoryContract> Process(ListJobCategoriesRequest input)
        {
            _query.BuildQuery(new ListJobCategories
            {
                OrganizationId = input.OrganizationId
            });

            var result = _runner.Run(_query);

            return result.Select(JobCategoriesMapper.Map);
        }
    }
}
