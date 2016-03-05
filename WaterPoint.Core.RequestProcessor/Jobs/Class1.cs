using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Jobs;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters;
using WaterPoint.Core.Domain.Requests;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.Jobs
{
    public class ListPriorityTypesProcessor
           : BaseDapperUowRequestProcess,
        IListProcessor<ListOrgEntitiesRequest, PriorityTypeContract>
    {
        private readonly IQuery<ListOrgEntities, PriorityType> _query;
        private readonly IQueryListRunner _runner;

        public ListPriorityTypesProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<ListOrgEntities, PriorityType> query,
            IQueryListRunner runner)
            : base(dapperUnitOfWork)
        {
            _query = query;
            _runner = runner;
        }

        public IEnumerable<PriorityTypeContract> Process(ListOrgEntitiesRequest input)
        {
            _query.BuildQuery(new ListOrgEntities
            {
                OrganizationId = input.OrganizationId
            });

            var result = _runner.Run(_query);

            return result.Select(PriorityTypeMapper.Map);
        }
    }
}
