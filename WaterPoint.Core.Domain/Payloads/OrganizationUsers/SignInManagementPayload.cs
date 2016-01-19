using System.ComponentModel.DataAnnotations;

namespace WaterPoint.Core.Domain.Payloads.OrganizationUsers
{
    public class SignInManagementPayload : IPayload
    {
        [Required]
        public int CredentialId { get; set; }

        [Required]
        public bool IsSignedIn { get; set; }
    }
}
