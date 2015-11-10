using WaterPoint.Core.Bll.Customers.Queries;
using WaterPoint.Core.Bll.Customers.Runners;
using WaterPoint.Core.ContractMapper;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Core.Domain.Requests.Customers;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.RequestProcessor.Customers
{
    public class GetCustomerByIdRequestProcessor :
        IRequestProcessor<GetCustomerByIdRequest, BasicCustomerContract>
    {
        private readonly IDapperUnitOfWork _dapperUnitOfWork;
        private readonly GetCustomerByIdQuery _command;
        private readonly GetCustomerByIdQueryRunner _runner;

        public GetCustomerByIdRequestProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            GetCustomerByIdQuery command,
            GetCustomerByIdQueryRunner runner)
        {
            _dapperUnitOfWork = dapperUnitOfWork;
            _command = command;
            _runner = runner;
        }

        public BasicCustomerContract Process(GetCustomerByIdRequest path)
        {
            _command.BuildQuery(path.OrganizationId, path.Id);

            using (_dapperUnitOfWork.Begin())
            {
                var customer = _runner.Run(_command);

                var result = CustomerMapper.Map(customer);

                return result;
            }
        }
    }
}
