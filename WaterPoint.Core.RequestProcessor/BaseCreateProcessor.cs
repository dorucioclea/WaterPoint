using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.RequestProcessor
{
    public abstract class BaseCreateProcessor<TRequest, TParameter> :
        BaseDapperUowRequestProcess,
        IWriteRequestProcessor<TRequest>
        where TRequest : IRequest
        where TParameter : IQueryParameter
    {
        private readonly ICommand<TParameter> _command;
        private readonly ICommandExecutor _executor;

        protected BaseCreateProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<TParameter> command,
            ICommandExecutor executor)
            : base(dapperUnitOfWork)
        {
            _command = command;
            _executor = executor;
        }

        public virtual CommandResult Process(TRequest input)
        {
            var result = UowProcess(ProcessDeFacto, input);

            return new CommandResult(result, result > 0);
        }

        public abstract TParameter BuildParameter(TRequest input);

        private int ProcessDeFacto(TRequest input)
        {
            _command.BuildQuery(BuildParameter(input));

            return _executor.Execute(_command);
        }
    }
}
