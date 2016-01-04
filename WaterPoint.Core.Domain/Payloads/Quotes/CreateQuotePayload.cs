using System.ComponentModel.DataAnnotations;

namespace WaterPoint.Core.Domain.Payloads.Quotes
{
    public class CreateQuotePayload
    {
        public int? JobId { get; set; }
        public int? ContactId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
