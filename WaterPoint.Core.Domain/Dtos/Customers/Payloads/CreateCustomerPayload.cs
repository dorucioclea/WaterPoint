using System;
using System.ComponentModel.DataAnnotations;

namespace WaterPoint.Core.Domain.Dtos.Customers.Payloads
{
    public class WriteCustomerPayload
    {
        public int? CustomerTypeId { get; set; }
        public string Code { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string OtherName { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public DateTime? Dob { get; set; }
    }
}
