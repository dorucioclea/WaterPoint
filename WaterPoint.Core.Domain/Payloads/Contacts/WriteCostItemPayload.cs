using System.ComponentModel.DataAnnotations;

namespace WaterPoint.Core.Domain.Payloads.Contacts
{
    public class CreateContactPayload : IPayload
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string OtherName { get; set; }

        public string Phone { get; set; }

        public string MobilePhone { get; set; }

        public string Email { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsPrimary { get; set; }
    }
}
