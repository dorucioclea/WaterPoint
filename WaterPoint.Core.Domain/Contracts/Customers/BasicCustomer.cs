using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Core.Domain.Contracts.Customers
{
    public class BasicCustomer
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }

    public class BasicCustomerWithAddress : BasicCustomer
    {
        public string Address { get; set; }
    }
}
