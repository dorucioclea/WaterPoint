using System;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.Bll.QueryParameters
{
    public class CreateJobQueryParameter : IQueryParameter
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
