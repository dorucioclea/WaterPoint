using System.ComponentModel.DataAnnotations;

namespace WaterPoint.Core.Domain.Requests.OAuthClients
{
    public class GetOAuthClientRequest : IRequest
    {
        [Required]
        public string ClientId { get; set; }

        [Required]
        public string ClientSecret { get; set; }
        
        public bool IsInternal { get; set; }
    }
}
