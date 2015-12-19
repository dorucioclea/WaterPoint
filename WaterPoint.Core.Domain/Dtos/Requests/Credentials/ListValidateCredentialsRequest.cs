using System.ComponentModel.DataAnnotations;

namespace WaterPoint.Core.Domain.Dtos.Requests.Credentials
{
    public class ListValidateCredentialsRequest : IRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
