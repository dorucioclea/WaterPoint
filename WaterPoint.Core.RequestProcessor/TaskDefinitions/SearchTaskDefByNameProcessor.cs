using System.Collections.Generic;
using System.Linq;
using WaterPoint.Core.Domain;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Core.Domain.Contracts.TaskDefinitions;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters;
using WaterPoint.Core.Domain.Requests;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.Pocos.TaskDefinitions;

namespace WaterPoint.Core.RequestProcessor.TaskDefinitions
{
    public class SearchTaskDefByNameProcessor : IListProcessor<SearchTermRequest, TaskDefinitionBasicContract>
    {
        private readonly IDapperUnitOfWork _dapperUnitOfWork;
        private readonly IQuery<SearchByName, TaskDefinitionBasicPoco> _listQuery;
        private readonly IQueryListRunner _runner;

        public SearchTaskDefByNameProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<SearchByName, TaskDefinitionBasicPoco> listQuery,
            IQueryListRunner runner)
        {
            _dapperUnitOfWork = dapperUnitOfWork;
            _listQuery = listQuery;
            _runner = runner;
        }

        public TaskDefinitionBasicContract Map(TaskDefinitionBasicPoco source)
        {
            return TaskDefinitionMapper.Map(source);
        }

        private SearchByName GetParameter(SearchTermRequest input)
        {
            return new SearchByName
            {
                OrganizationId = input.OrganizationId,
                SearchTerm = input.SearchTerm
            };
        }

        public IEnumerable<TaskDefinitionBasicContract> Process(SearchTermRequest input)
        {
            using (_dapperUnitOfWork.Begin())
            {
                try
                {
                    _listQuery.BuildQuery(GetParameter(input));

                    var result = _runner.Run(_listQuery);

                    _dapperUnitOfWork.Commit();

                    return result.Select(Map);
                }
                catch
                {
                    _dapperUnitOfWork.Rollback();

                    throw;
                }
            }
        }
    }
}
