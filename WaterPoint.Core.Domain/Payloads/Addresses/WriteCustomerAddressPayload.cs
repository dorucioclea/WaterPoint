using System.ComponentModel.DataAnnotations;

namespace WaterPoint.Core.Domain.Payloads.Addresses
{
    public class WriteCustomerAddressPayload : IPayload
    {
        [Required]
        public int AddressId { get; set; }

        public bool? IsPrimary { get; set; }

        public bool? IsPostAddress { get; set; }
    }
}
