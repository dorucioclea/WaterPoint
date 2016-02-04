using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Credentials;
using WaterPoint.Core.Domain.QueryParameters.OrganizationUsers;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Commands.OrganizationUsers
{
    public class CreateOrganizationUserCommand : ICommand<CreateOrganizationUser>
    {
        public void BuildQuery(CreateOrganizationUser input)
        {
            Query = "[dbo].[Add_OrganizationUser]";
            Parameters = null;
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
        public bool IsStoredProcedure => true;
    }
}
