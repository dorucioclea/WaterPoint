using System.ComponentModel.DataAnnotations;

namespace WaterPoint.Core.Domain.Payloads.OrganizationUsers
{
    public class SignInManagementPayload : IPayload
    {
        public bool ToSignIn { get; set; }
    }
}
