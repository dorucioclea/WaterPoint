using WaterPoint.Core.Bll.Customers.Queries;
using WaterPoint.Core.Bll.Customers.Runners;
using WaterPoint.Core.ContractMapper;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Core.Domain.RequestDtos;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.RequestProcessor.Customers
{
    public class GetCustomerByIdRequestProcessor :
        BaseDapperUowRequestProcess,
        IRequestProcessor<OrganizationEntityRequest, CustomerContract>
    {
        private readonly GetCustomerByIdQuery _command;
        private readonly GetCustomerByIdQueryRunner _runner;

        public GetCustomerByIdRequestProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            GetCustomerByIdQuery command,
            GetCustomerByIdQueryRunner runner)
            : base(dapperUnitOfWork)
        {
            _command = command;
            _runner = runner;
        }

        public CustomerContract Process(OrganizationEntityRequest path)
        {
            _command.BuildQuery(path.OrganizationId, path.Id);

            using (DapperUnitOfWork.Begin())
            {
                var customer = _runner.Run(_command);

                var result = CustomerMapper.Map(customer);

                return result;
            }
        }
    }
}
