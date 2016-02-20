using System;
using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.Staff
{
    public class CreateStaff : IQueryParameter
    {
        public int OrganizationId { get; set; }

        public int OrganizationUserId { get; set; }

        public string Gender { get; set; }

        public string Code { get; set; }

        public string ContactEmail { get; set; }

        public decimal BaseRate { get; set; }

        public decimal BillableRate { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string OtherName { get; set; }

        public string MobilePhone { get; set; }

        public string Phone { get; set; }

        public DateTime? Dob { get; set; }
    }
}
