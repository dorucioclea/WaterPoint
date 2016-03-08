using System;
using WaterPoint.Api.Common;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Exceptions;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity;

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
        private readonly IQuery<TGetParameter, TGetEntity> _getQuery;
        private readonly IQueryRunner _getQueryRunner;
        private readonly ICommand<TUpdateParameter> _updateQuery;
        protected ICommandExecutor CommandExecutor { get; private set; }

        protected BaseUpdateProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IPatchEntityAdapter patchEntityAdapter,
            IQuery<TGetParameter, TGetEntity> getQuery,
            IQueryRunner getQueryRunner,
            ICommand<TUpdateParameter> updateQuery,
            ICommandExecutor updateCommandExecutor)
            : base(dapperUnitOfWork)
        {
            _patchEntityAdapter = patchEntityAdapter;
            _getQuery = getQuery;
            _getQueryRunner = getQueryRunner;
            _updateQuery = updateQuery;
            CommandExecutor = updateCommandExecutor;
        }

        public virtual CommandResult Process(TUpdateRequest input)
        {
            var result = UowProcess(PatchExecution, input);

            return new CommandResult(result, result > 0);
        }

        public abstract TGetParameter BuildGetParameter(TUpdateRequest input);

        public int PatchExecution(TUpdateRequest input)
        {
            var getParam = BuildGetParameter(input);

            _getQuery.BuildQuery(getParam);

            var existing = _getQueryRunner.Run(_getQuery);

            if (existing == null)
                throw new NotFoundException();

            var updated =
                _patchEntityAdapter.PatchEnitity<TPayload, TGetEntity, TUpdateParameter>
                (
                    existing,
                    input.Payload.Patch
                );

            //then build the query to update the object.
            _updateQuery.BuildQuery(updated);

            return CommandExecutor.ExecuteNonQuery(_updateQuery);
        }
    }
}
