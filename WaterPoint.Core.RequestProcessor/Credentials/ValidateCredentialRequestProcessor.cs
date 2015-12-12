using WaterPoint.Core.Bll.Queries.Credentials;
using WaterPoint.Core.Bll.QueryRunners.Credentials;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Dtos.Requests.Credentials;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.RequestProcessor.Credentials
{
    public class ValidateCredentialRequestProcessor :
        BaseDapperUowRequestProcess,
        IRequestProcessor<ValidateCredentialRequest, bool>
    {
        private readonly ValidateCredentialQuery _query;
        private readonly ValidateCredentialQueryRunner _runner;

        public ValidateCredentialRequestProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ValidateCredentialQuery query,
            ValidateCredentialQueryRunner runner)
            : base(dapperUnitOfWork)
        {
            _query = query;
            _runner = runner;
        }

        public bool Process(ValidateCredentialRequest input)
        {
            _query.BuildQuery(input.Username, input.Password);

            using (DapperUnitOfWork.Begin())
            {
                var isValid = _runner.Run(_query);

                return isValid;
            }
        }
    }
}
