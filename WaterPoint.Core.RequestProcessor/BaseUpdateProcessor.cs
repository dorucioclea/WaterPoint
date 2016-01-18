﻿using WaterPoint.Api.Common;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor
{
    public abstract class BaseUpdateProcessor<TUpdateRequest, TPayload, TUpdateParameter, TGetParameter, TGetEntity> :
        BaseDapperUowRequestProcess,
        IWriteRequestProcessor<TUpdateRequest>
        where TUpdateRequest : IUpdateRequest<TPayload>
        where TPayload : class, IPayload, new()
        where TGetParameter : IQueryParameter
        where TGetEntity : class, IDataEntity
        where TUpdateParameter : class, IQueryParameter, new()
    {
        private readonly IPatchEntityAdapter _patchEntityAdapter;
        private readonly IQuery<TGetParameter> _getQuery;
        private readonly IQueryRunner<TGetParameter, TGetEntity> _getQueryRunner;
        private readonly ICommand<TUpdateParameter> _updateQuery;
        private readonly ICommandExecutor<TUpdateParameter> _updateCommandExecutor;

        protected BaseUpdateProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IPatchEntityAdapter patchEntityAdapter,
            IQuery<TGetParameter> getQuery,
            IQueryRunner<TGetParameter, TGetEntity> getQueryRunner,
            ICommand<TUpdateParameter> updateQuery,
            ICommandExecutor<TUpdateParameter> updateCommandExecutor)
            : base(dapperUnitOfWork)
        {
            _patchEntityAdapter = patchEntityAdapter;
            _getQuery = getQuery;
            _getQueryRunner = getQueryRunner;
            _updateQuery = updateQuery;
            _updateCommandExecutor = updateCommandExecutor;
        }

        public virtual CommandResult Process(TUpdateRequest input)
        {
            var result = UowProcess(ProcessDeFacto, input);

            return new CommandResult(result, result > 0);
        }

        public abstract TGetParameter BuildGetParameter(TUpdateRequest input);

        private int ProcessDeFacto(TUpdateRequest input)
        {
            var getParam = BuildGetParameter(input);

            _getQuery.BuildQuery(getParam);

            var existing = _getQueryRunner.Run(_getQuery);

            var updated =
                _patchEntityAdapter.PatchEnitity<TPayload, TGetEntity, TUpdateParameter>
                (
                    existing,
                    input.Payload.Patch
                );

            //then build the query to update the object.
            _updateQuery.BuildQuery(updated);

            return _updateCommandExecutor.Execute(_updateQuery);
        }
    }
}