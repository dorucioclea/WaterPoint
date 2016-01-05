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
    public abstract class PagedProcessor<TRequest, TParameter, TDataEntity, TContract> :
        IPagedProcessor<TRequest, TContract>
        where TContract : IContract
        where TRequest : IRequest
        where TParameter : class, IPagedQueryParameter, new()
        where TDataEntity : IDataEntity, new()
    {
        private readonly IDapperUnitOfWork _dapperUnitOfWork;
        private readonly IQuery<TParameter> _listQuery;
        private readonly IPagedQueryRunner<TParameter, TDataEntity> _listQueryRunner;

        protected PagedProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<TParameter> listQuery,
            IPagedQueryRunner<TParameter, TDataEntity> listQueryRunner)
        {
            _dapperUnitOfWork = dapperUnitOfWork;
            _listQuery = listQuery;
            _listQueryRunner = listQueryRunner;
        }

        public abstract TContract Map(TDataEntity source);

        public virtual TParameter GetParameter(TRequest input)
        {
            return input == null ? null : input.ConvertToParameter<TParameter>();
        }

        public virtual PagedResult<TContract> Process(TRequest input)
        {
            var parameter = GetParameter(input);

            _listQuery.BuildQuery(parameter);

            using (_dapperUnitOfWork.Begin())
            {
                var result = _listQueryRunner.Run(_listQuery);

                return new PagedResult<TContract>
                {
                    Data = result.Data.Select(Map),
                    TotalCount = result.TotalCount,
                    PageNumber = parameter.PageNumber,
                    PageSize = parameter.PageSize,
                    Sort = parameter.Sort,
                    IsDesc = parameter.IsDesc
                };
            }
        }
    }
}
