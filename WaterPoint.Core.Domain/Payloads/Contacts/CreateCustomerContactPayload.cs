using System.ComponentModel.DataAnnotations;

namespace WaterPoint.Core.Domain.Payloads.Contacts
{
    public class CreateCustomerContactPayload : IPayload
    {
        [Required]
        public int ContactId { get; set; }

        public bool? IsPrimary { get; set; }
    }
}
