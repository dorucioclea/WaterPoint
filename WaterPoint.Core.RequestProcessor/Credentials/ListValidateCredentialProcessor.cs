using System.Collections.Generic;
using System.Linq;
using WaterPoint.Core.Domain.QueryParameters.Credentials;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Credentials;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Requests.Credentials;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.Pocos.Views;

namespace WaterPoint.Core.RequestProcessor.Credentials
{
    public class ListValidateCredentialProcessor :
        BaseDapperUowRequestProcess,
        IRequestListProcessor<ListValidateCredentialsRequest, ValidCredentialContract>
    {
        private readonly IQuery<ListCredentials> _query;
        private readonly IQueryListRunner<ListCredentials, ValidCredential> _runner;

        public ListValidateCredentialProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<ListCredentials> query,
            IQueryListRunner<ListCredentials, ValidCredential> runner)
            : base(dapperUnitOfWork)
        {
            _query = query;
            _runner = runner;
        }

        public IEnumerable<ValidCredentialContract> Process(ListValidateCredentialsRequest input)
        {
            var parameter = new ListCredentials
            {
                Email = input.Username,
                Password = input.Password
            };

            _query.BuildQuery(parameter);

            using (DapperUnitOfWork.Begin())
            {
                var credentials = _runner.Run(_query);

                return credentials.Select(CredentialMapper.Map);
            }
        }
    }
}
