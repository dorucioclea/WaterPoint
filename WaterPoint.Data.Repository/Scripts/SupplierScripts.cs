using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Data.Repository
{
    public class SupplierScripts
    {
        private const string Fields = @"
            [Id]
            ,[Name]
            ,[DisplayName]
            ,[Mobile]
            ,[Phone1]
            ,CONVERT(VARCHAR(36), [Uid]) AS Uid";

        public static string ListAllAsync = string.Format(@"SELECT {0} FROM [dbo].[Supplier] WHERE OrganizationId = @organizationId", Fields);

        public static string GetAsync = string.Format(
            @"
                SELECT {0} FROM [dbo].[Supplier] 
                WHERE 
                    Id = @id 
                    AND OrganizationId = @organizationId", Fields);
    }
}
