using System.Linq;
using WaterPoint.Api.Common;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity;

namespace WaterPoint.Core.RequestProcessor
{
    public abstract class SimplePagedProcessor<TRequest, TParameter, TDataEntity, TContract> :
        ISimplePagedProcessor<TRequest, TContract>
        where TContract : IContract
        where TRequest : IRequest
        where TParameter : IQueryParameter
        where TDataEntity : IDataEntity, new()
    {
        private readonly IDapperUnitOfWork _dapperUnitOfWork;
        private readonly IQuery<TParameter> _listQuery;
        private readonly IPagedQueryRunner<TParameter, TDataEntity> _listQueryRunner;

        protected SimplePagedProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<TParameter> listQuery,
            IPagedQueryRunner<TParameter, TDataEntity> listQueryRunner,
            SimplePaginationParameterConverter converter)
        {
            _dapperUnitOfWork = dapperUnitOfWork;
            _listQuery = listQuery;
            _listQueryRunner = listQueryRunner;
            Converter = converter;
        }

        public SimplePaginationParameterConverter Converter { get; private set; }

        public abstract TContract Map(TDataEntity source);

        public abstract TParameter GetParameter(TRequest input);

        public virtual SimplePagedResult<TContract> Process(TRequest input)
        {
            var parameter = GetParameter(input);

            _listQuery.BuildQuery(parameter);

            using (_dapperUnitOfWork.Begin())
            {
                var result = _listQueryRunner.Run(_listQuery);

                return new SimplePagedResult<TContract>
                {
                    Data = result.Data.Select(Map),
                    TotalCount = result.TotalCount,
                    PageNumber = Converter.PageNumber,
                    PageSize = Converter.PageSize
                };
            }
        }
    }
}
