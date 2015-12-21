using System;
using WaterPoint.Core.Domain;

namespace WaterPoint.Core.Bll.QueryParameters.Jobs
{
    public class CreateBasicJobQueryParameter : IQueryParameter
    {
        public int OrganizationId { get; set; }
        public int JobStatusId { get; set; }
        public string Code { get; set; }
        public string ShortDescription { get; set; }
        public int CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
