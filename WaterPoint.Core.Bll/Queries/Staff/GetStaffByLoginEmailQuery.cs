using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Staff;

namespace WaterPoint.Core.Bll.Queries.Staff
{
    public class GetStaffByLoginEmailQuery : IQuery<GetStaffByLoginEmail, Data.Entity.DataEntities.Staff>
    {
        public void BuildQuery(GetStaffByLoginEmail parameter)
        {
            Query = "[dbo].[Get_Staff_By_LoginEmail]";

            Parameters = new
            {
                organizationId = parameter.OrganizationId,
                loginemail = parameter.Email
            };
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
        public bool IsStoredProcedure => true;
    }
}
