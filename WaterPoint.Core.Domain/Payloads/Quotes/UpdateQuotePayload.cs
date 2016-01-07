using System.ComponentModel.DataAnnotations;

namespace WaterPoint.Core.Domain.Payloads.Quotes
{
    public class UpdateQuotePayload : IPayload
    {
        public int? ContactId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
    }
}
