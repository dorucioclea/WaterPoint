using System;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Bll.QueryParameters.Jobs
{
    public class CreateBasicJob : IQueryParameter
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
