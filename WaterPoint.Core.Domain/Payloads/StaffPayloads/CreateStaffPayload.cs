using System;
using System.ComponentModel.DataAnnotations;

namespace WaterPoint.Core.Domain.Payloads.StaffPayloads
{
    public class CreateStaffPayload : IPayload
    {
        [RegularExpression("^[mfMF]$", ErrorMessage = "value can only be m, f, M, F, or null")]
        public string Gender { get; set; }

        public bool IsAdmin { get; set; }

        public string Code { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [EmailAddress]
        public string ContactEmail { get; set; }

        public decimal BaseRate { get; set; }

        public decimal BillableRate { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string OtherName { get; set; }

        public string Phone { get; set; }

        public string MobilePhone { get; set; }

        public DateTime? Dob { get; set; }
    }
}
