using System;
using System.ComponentModel.DataAnnotations;

namespace WaterPoint.Core.Domain.RequestDtos.Customers
{
    public class CreateCustomerPayload
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

    public class UpdateCustomerPayload : CreateCustomerPayload
    {
        [Required]
        public int Id { get; set; }
    }
}
