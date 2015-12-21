using System;
using System.Collections.Generic;
using WaterPoint.Core.Bll.Queries.Credentials;
using WaterPoint.Core.Bll.QueryParameters.Credentials;
using WaterPoint.Core.Bll.QueryRunners.Credentials;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Dtos.Requests.Credentials;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.Pocos.Views;

namespace WaterPoint.Core.RequestProcessor.Credentials
{
    public class ListValidateCredentialRequestProcessor :
        BaseDapperUowRequestProcess,
        IRequestProcessor<ListValidateCredentialsRequest, IEnumerable<ValidCredential>>
    {
        private readonly IQuery<ListCredentialsQueryParameter> _query;
        private readonly IQueryRunner<ListCredentialsQueryParameter, IEnumerable<ValidCredential>> _runner;

        public ListValidateCredentialRequestProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<ListCredentialsQueryParameter> query,
            IQueryRunner<ListCredentialsQueryParameter, IEnumerable<ValidCredential>> runner)
            : base(dapperUnitOfWork)
        {
            _query = query;
            _runner = runner;
        }

        public IEnumerable<ValidCredential> Process(ListValidateCredentialsRequest input)
        {
            var parameter = new ListCredentialsQueryParameter
            {
                Email = input.Username,
                Password = input.Password
            };

            _query.BuildQuery(parameter);

            using (DapperUnitOfWork.Begin())
            {
                var credentials = _runner.Run(_query);

                return credentials;
            }
        }
    }
}
