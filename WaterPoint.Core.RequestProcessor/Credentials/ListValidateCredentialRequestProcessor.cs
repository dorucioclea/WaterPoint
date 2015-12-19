using System;
using System.Collections.Generic;
using WaterPoint.Core.Bll.Queries.Credentials;
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
        private readonly ListValidateCredentialsQuery _query;
        private readonly ListValidateCredentialsRunner _runner;

        public ListValidateCredentialRequestProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ListValidateCredentialsQuery query,
            ListValidateCredentialsRunner runner)
            : base(dapperUnitOfWork)
        {
            _query = query;
            _runner = runner;
        }

        public IEnumerable<ValidCredential> Process(ListValidateCredentialsRequest input)
        {
            _query.BuildQuery(input.Username, input.Password);

            using (DapperUnitOfWork.Begin())
            {
                var credentials = _runner.Run(_query);

                return credentials;
            }
        }
    }
}
