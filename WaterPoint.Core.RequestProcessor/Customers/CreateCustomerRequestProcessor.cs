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
        IRequestProcessor<CreateCustomerRequest, CustomerContract>
    {
        private readonly CreateCustomersCommand _command;
        private readonly WriteCommandExecutor _executor;

        public CreateCustomerRequestProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            CreateCustomersCommand command,
            WriteCommandExecutor executor)
            : base(dapperUnitOfWork)
        {
            _command = command;
            _executor = executor;
        }

        public CustomerContract Process(CreateCustomerRequest input)
        {
            var customer = new Customer
            {
                OrganizationId = input.OrganizationIdParameter.OrganizationId,
                Code = input.CreateCustomerPayload.Code,
                CustomerTypeId = input.CreateCustomerPayload.CustomerTypeId,
                Dob = input.CreateCustomerPayload.Dob,
                Email = input.CreateCustomerPayload.Email,
                FirstName = input.CreateCustomerPayload.FirstName,
                LastName = input.CreateCustomerPayload.LastName,
                MobilePhone = input.CreateCustomerPayload.MobilePhone,
                OtherName = input.CreateCustomerPayload.OtherName,
                Phone = input.CreateCustomerPayload.Phone
            };

            _command.BuildQuery(input.OrganizationIdParameter.OrganizationId, customer);

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
