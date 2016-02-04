using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Bll.Executors;
using WaterPoint.Core.Bll.Queries.Credentials;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Credentials;
using WaterPoint.Core.Domain.QueryParameters.OrganizationUsers;
using WaterPoint.Core.Domain.QueryParameters.Staff;
using WaterPoint.Core.Domain.Requests.Staff;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.Views;

namespace WaterPoint.Core.RequestProcessor.Staff
{
    public class CreateStaffProcessor :
        BaseDapperUowRequestProcess,
        IWriteRequestProcessor<CreateStaffRequest>
    {
        private readonly ICommand<CreateCredential> _createCredential;
        private readonly ICommand<CreateOrganizationUser> _createOrganizationUser;
        private readonly ICommandExecutor _executor;

        public CreateStaffProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<GetCredential, Credential> getCredential,
            IQuery<GetStaffByLogin, Data.Entity.DataEntities.Staff> getStaffByLogin,
            ICommand<CreateCredential> createCredential,
            ICommand<CreateOrganizationUser> createOrganizationUser,
            ICommandExecutor executor)
            : base(dapperUnitOfWork)
        {
            _createCredential = createCredential;
            _createOrganizationUser = createOrganizationUser;
            _executor = executor;
        }

        public virtual CommandResult Process(CreateStaffRequest input)
        {
            var result = UowProcess(ProcessDeFacto, input);

            return new CommandResult(result, result > 0);
        }

        private int ProcessDeFacto(CreateStaffRequest input)
        {
            //check staff with the same login exists or not
            //if yes no process
            //if no continue

            //check credential exists

            //if yes isDeleted? yes undelete, no use it

            //if not create credential
            var credentialId = _executor.ExecuteInsert(_createCredential);

            //check organization user with the credentialid orgid + credentialid combination should be unique

            //if yes, is deleted ?

            //if no create

            //create staff


            //_command.BuildQuery(BuildParameter(input));

            //return _executor.Execute(_command);
            throw new NotImplementedException();
        }
    }
}
