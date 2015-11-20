using WaterPoint.Core.Bll;
using WaterPoint.Core.Bll.Customers.Commands;
using WaterPoint.Core.ContractMapper;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Core.Domain.RequestDtos;
using WaterPoint.Core.Domain.RequestDtos.Customers;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.Customers
{
    public class CreateCustomerRequestProcessor :
        BaseDapperUowRequestProcess,
        ICreateRequestProcessor<OrganizationIdRequest, CreateCustomerRequest, CustomerContract>
    {
        private readonly CreateCustomersCommand _command;
        private readonly CreateCommandExecutor _executor;

        public CreateCustomerRequestProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            CreateCustomersCommand command,
            CreateCommandExecutor executor)
            : base(dapperUnitOfWork)
        {
            _command = command;
            _executor = executor;
        }

        public CustomerContract Process(OrganizationIdRequest pathInput, CreateCustomerRequest input)
        {
            var customer = new Customer
            {
                OrganizationId = pathInput.OrganizationId,
                Code = input.Code,
                CustomerTypeId = input.CustomerTypeId,
                Dob = input.Dob,
                Email = input.Email,
                FirstName = input.FirstName,
                LastName = input.LastName,
                MobilePhone = input.MobilePhone,
                OtherName = input.OtherName,
                Phone = input.Phone
            };

            _command.BuildQuery(pathInput.OrganizationId, customer);

            using (DapperUnitOfWork.Begin())
            {
                try
                {
                    var newId = _executor.Run(_command);

                    customer.Id = newId;

                    var result = CustomerMapper.Map(customer);

                    DapperUnitOfWork.Commit();

                    return result;
                }
                catch
                {
                    DapperUnitOfWork.Rollback();
                    throw;
                }
            }
        }
    }
}
