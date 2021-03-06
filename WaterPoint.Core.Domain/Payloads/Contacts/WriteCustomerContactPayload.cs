using System.ComponentModel.DataAnnotations;

namespace WaterPoint.Core.Domain.Payloads.Contacts
{
    public class WriteCustomerContactPayload : IPayload
    {
        [Required]
        public int ContactId { get; set; }

        public bool? IsPrimary { get; set; }
    }
}
