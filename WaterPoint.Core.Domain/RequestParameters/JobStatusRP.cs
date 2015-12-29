using System.ComponentModel.DataAnnotations;
using WaterPoint.Core.Domain.RequestParameters.Interfaces;

namespace WaterPoint.Core.Domain.RequestParameters
{
    public class JobStatusRp : IOrgId
    {
        //[RegularExpression(@"\b^((?i)inprogress|cancelled|planned|deleted|onhold|completed?(?-i))$\b")]
        public string Status { get; set; }
        public int OrganizationId { get; set; }
    }
}
