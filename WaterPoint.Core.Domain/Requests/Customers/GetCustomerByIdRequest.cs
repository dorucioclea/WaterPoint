using System;
using System.ComponentModel.DataAnnotations;

namespace WaterPoint.Core.Domain.Requests.Customers
{
    public class GetCustomerByIdRequest : IUriPathRequest
    {
        public int OrganizationId { get; set; }
        public int Id { get; set; }
    }
}
