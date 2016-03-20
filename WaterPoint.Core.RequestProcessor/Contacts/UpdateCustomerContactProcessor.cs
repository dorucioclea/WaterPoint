using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Contacts;
using WaterPoint.Core.Domain.Requests.Contacts;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.RequestProcessor.Contacts
{
    public class UpdateCustomerContactProcessor// 
        : BaseDapperUowRequestProcess,
        IWriteRequestProcessor<UpdateCustomerContactRequest>
    {
        private readonly ICommand<UpdateCustomerContactIsPrimary> _updateCustomerContactPrimary;
        private readonly ICommandExecutor _commandExecutor;

        public UpdateCustomerContactProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<UpdateCustomerContactIsPrimary> updateCustomerContactPrimary,
            ICommandExecutor updateCommandExecutor)
                : base(dapperUnitOfWork)
        {
            _updateCustomerContactPrimary = updateCustomerContactPrimary;
            _commandExecutor = updateCommandExecutor;
        }


        public CommandResult Process(UpdateCustomerContactRequest input)
        {
            var result = UowProcess(Execution, input);

            return new ObjectsCountCommandResult(result, result > 0);
        }

        public int Execution(UpdateCustomerContactRequest input)
        {
            var entity = input.Payload.GetEntity();

            if (!entity.IsPrimary.HasValue)
                return 0;

            _updateCustomerContactPrimary.BuildQuery(new UpdateCustomerContactIsPrimary
            {
                CustomerId = input.CustomerId,
                OrganizationId = input.OrganizationId,
                IsPrimary = entity.IsPrimary.Value,
                ContactId = input.ContactId
            });

            return _commandExecutor.ExecuteNonQuery(_updateCustomerContactPrimary);
        }
    }
}
