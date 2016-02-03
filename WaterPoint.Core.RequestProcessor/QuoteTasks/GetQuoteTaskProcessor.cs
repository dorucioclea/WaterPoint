using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.QuoteTasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.QuoteTasks;
using WaterPoint.Core.Domain.Requests.QuoteTasks;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.QuoteTasks
{
    public class GetQuoteTaskProcessor : BaseDapperUowRequestProcess,
        IRequestProcessor<GetQuoteTaskRequest, QuoteTaskContract>
    {
        private readonly IQuery<GetQuoteTask, QuoteTask> _query;
        private readonly IQueryRunner _runner;

        public GetQuoteTaskProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<GetQuoteTask, QuoteTask> query,
            IQueryRunner runner)
            : base(dapperUnitOfWork)
        {
            _query = query;
            _runner = runner;
        }

        public QuoteTaskContract Process(GetQuoteTaskRequest input)
        {
            _query.BuildQuery(new GetQuoteTask
            {
                Id = input.Id,
                OrganizationId = input.OrganizationId,
                QuoteId = input.QuoteId
            });

            using (DapperUnitOfWork.Begin())
            {
                var quotetask = _runner.Run(_query);

                var result = QuoteTaskMapper.Map(quotetask);

                return result;
            }
        }
    }
}
