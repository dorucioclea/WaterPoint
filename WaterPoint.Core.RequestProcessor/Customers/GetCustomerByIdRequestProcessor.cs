using System;
using WaterPoint.Api.Common;
using WaterPoint.Core.Bll;
using WaterPoint.Core.Bll.Customers.Commands;
using WaterPoint.Core.Bll.Customers.Queries;
using WaterPoint.Core.Bll.Customers.Runners;
using WaterPoint.Core.ContractMapper;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Core.Domain.Requests;
using WaterPoint.Core.Domain.Requests.Customers;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.Customers
{
    public class CreateCustomerRequestProcessor :
        ICreateRequestProcessor<OrganizationIdRequest, CreateCustomerRequest, BasicCustomerContract>
    {
        private readonly IDapperUnitOfWork _dapperUnitOfWork;
        private readonly CreateCustomersCommand _command;
        private readonly CreateCommandExecutor _executor;

        public CreateCustomerRequestProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            CreateCustomersCommand command,
            CreateCommandExecutor executor)
        {
            _dapperUnitOfWork = dapperUnitOfWork;
            _command = command;
            _executor = executor;
        }

        public BasicCustomerContract Process(OrganizationIdRequest pathInput, CreateCustomerRequest input)
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

            using (_dapperUnitOfWork.Begin())
            {
                try
                {
                    var newId = _executor.Run(_command);

                    customer.Id = newId;

                    var result = CustomerMapper.Map(customer);

                    _dapperUnitOfWork.Commit();

                    return result;
                }
                catch
                {
                    _dapperUnitOfWork.Rollback();
                    throw;
                }
            }
        }
    }
}
