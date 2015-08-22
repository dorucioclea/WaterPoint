using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Data.Repository
{
    public class RestaurantScripts
    {
        private const string Fields = @"
            [Id]
            ,[Name]
            ,[DisplayName]
            ,[LogoImageId]
            ,[InvoiceDueDate]
            ,[InvoiceDueDaysAfterInvoiced]
            ,[TaxCode]
            ,[InvoiceNote]
            ,[PurchaseOrderNote]
            ,[InvoiceNumberCode]
            ,[PurchaseOrderNumberCode]
            ,CONVERT(VARCHAR(36), [Uid]) AS Uid ";

        public static string GetAsync = string.Format(
            @"
            SELECT
                {0}
            FROM
                [dbo].[Restaurant] 
            WHERE 
                Id = @id ", Fields);
    }
}
