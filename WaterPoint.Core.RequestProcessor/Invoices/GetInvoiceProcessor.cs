using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Invoices;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters;
using WaterPoint.Core.Domain.Requests;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.Invoices
{
    public class GetInvoiceProcessor :
        BaseDapperUowRequestProcess,
        IRequestProcessor<OrganizationEntityRequest, InvoiceContract>
    {
        private readonly IQuery<GetOrganizationEntity, Invoice> _query;
        private readonly IQueryRunner _runner;

        public GetInvoiceProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<GetOrganizationEntity, Invoice> query,
            IQueryRunner runner)
                : base(dapperUnitOfWork)
        {
            _query = query;
            _runner = runner;
        }

        public InvoiceContract Process(OrganizationEntityRequest input)
        {
            var parameter = new GetOrganizationEntity
            {
                OrganizationId = input.OrganizationId,
                Id = input.Id
            };

            _query.BuildQuery(parameter);

            using (DapperUnitOfWork.Begin())
            {
                var invoice = _runner.Run(_query);

                var result = InvoiceMapper.Map(invoice);

                return result;
            }
        }
    }
}
