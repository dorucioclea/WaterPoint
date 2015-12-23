using System;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity.Attributes;

namespace WaterPoint.Core.Bll.QueryParameters.TaskDefinitions
{
    public class UpdateTaskDefinition : IQueryParameter
    {
        [IgnoreWhenUpdate]
        public int Id { get; set; }

        [IgnoreWhenUpdate]
        public int OrganizationId { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public decimal BaseRate { get; set; }

        public decimal BillableRate { get; set; }
    }
}
