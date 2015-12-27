using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Core.Domain.Contracts.Staff
{
    public class StaffContract : IContract
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public int OrganizationUserId { get; set; }
        public decimal BaseRate { get; set; }
        public decimal BillableRate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherName { get; set; }
        public string MobilePhone { get; set; }
        public DateTime? Dob { get; set; }
        public string Version { get; set; }
        public DateTime UtcCreated { get; set; }
        public DateTime UtcUpdated { get; set; }
        public string Uid { get; set; }
    }
}
