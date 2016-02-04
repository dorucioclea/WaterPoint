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
using OrgStaff = WaterPoint.Data.Entity.DataEntities.Staff;

namespace WaterPoint.Core.RequestProcessor.Staff
{
    public class CreateStaffProcessor :
        BaseDapperUowRequestProcess,
        IWriteRequestProcessor<CreateStaffRequest>
    {
        private readonly IQuery<GetStaffByLoginEmail, OrgStaff> _getStaffByLogin;
        private readonly IQuery<GetCredential, Credential> _getCredential;
        private readonly ICommand<CreateCredential> _createCredential;
        private readonly ICommand<CreateOrganizationUser> _createOrganizationUser;
        private readonly ICommandExecutor _executor;
        private readonly IQueryRunner _queryRunner;

        public CreateStaffProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<GetStaffByLoginEmail, OrgStaff> getStaffByLogin,
            IQuery<GetCredential, Credential> getCredential,
            ICommand<CreateCredential> createCredential,
            ICommand<CreateOrganizationUser> createOrganizationUser,
            ICommandExecutor executor,
            IQueryRunner queryRunner)
            : base(dapperUnitOfWork)
        {
            _getStaffByLogin = getStaffByLogin;
            _getCredential = getCredential;
            _createCredential = createCredential;
            _createOrganizationUser = createOrganizationUser;
            _executor = executor;
            _queryRunner = queryRunner;
        }

        public virtual CommandResult Process(CreateStaffRequest input)
        {
            var result = UowProcess(ProcessDeFacto, input);

            return new CommandResult(result, result > 0);
        }

        private int ProcessDeFacto(CreateStaffRequest input)
        {
            //check staff with the same login exists or not
            var alreadyCreatedStaff = _queryRunner.Run(_getStaffByLogin);

            if (alreadyCreatedStaff.IsDeleted)
            {
                //undelete
                return alreadyCreatedStaff.Id;
            }

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
