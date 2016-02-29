using System;
using System.ComponentModel.DataAnnotations;

namespace WaterPoint.Core.Domain.Payloads.Customers
{
    public class WriteCustomerPayload : IPayload
    {
        [Required]
        public int CustomerTypeId { get; set; }

        public bool IsProspect { get; set; }

        [RegularExpression("^[mfMF]$", ErrorMessage = "value can only be m, f, M, F, or null")]
        public string Gender { get; set; }

        public string Code { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string OtherName { get; set; }

        public string Phone { get; set; }

        public string MobilePhone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public DateTime? Dob { get; set; }
    }
}
