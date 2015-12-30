using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
