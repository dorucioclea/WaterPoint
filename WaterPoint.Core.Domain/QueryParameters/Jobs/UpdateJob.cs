using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity.Attributes;

namespace WaterPoint.Core.Domain.QueryParameters.Jobs
{
    public class UpdateJob : IQueryParameter
    {
        [IgnoreWhenUpdate]
        public int Id { get; set; }

        [IgnoreWhenUpdate]
        public int OrganizationId { get; set; }

        public int JobStatusId { get; set; }

        public int? PriorityTypeId { get; set; }

        public int? JobCategoryId { get; set; }

        public string Code { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public int CustomerId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime? DueDate { get; set; }

        public decimal? Budget { get; set; }

        public decimal ExcludeFromWip { get; set; }
    }
}
