using System.ComponentModel.DataAnnotations;

namespace WaterPoint.Core.Domain.Dtos.RequestParameters
{
    public class JobStatusRp
    {
        //[RegularExpression(@"\b^((?i)inprogress|cancelled|planned|deleted|onhold|completed?(?-i))$\b")]
        public string Status { get; set; }
    }
}
