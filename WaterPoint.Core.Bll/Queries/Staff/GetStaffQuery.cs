using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Staff;

namespace WaterPoint.Core.Bll.Queries.Staff
{
    public class GetStaffQuery : IQuery<GetStaff>
    {
        public void BuildQuery(GetStaff parameter)
        {
            Query = "[dbo].[Get_Staff_By_Id]";

            Parameters = new
            {
                organizationId = parameter.OrganizationId,
                id = parameter.Id
            };
        }

        public bool IsStoredProcedure => true;
        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
