using System.Collections.Generic;
using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.Customers
{
    public class DeleteCustomer : IQueryParameter
    {
        public int OrganizationId { get; set; }

        public string Customers { get; set; }
    }
}
