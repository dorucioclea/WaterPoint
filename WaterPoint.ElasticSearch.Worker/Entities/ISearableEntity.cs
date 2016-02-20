using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.ElasticSearch.Worker.Entities
{
    public interface ISearableEntity
    {
        int Id { get; set; }
        int OrganizationId { get; set; }
    }
}
