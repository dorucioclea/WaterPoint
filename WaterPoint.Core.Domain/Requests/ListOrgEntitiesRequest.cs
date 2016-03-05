using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Core.Domain.Requests
{
    public class ListOrgEntitiesRequest : IRequest
    {
        public int OrganizationId { get; set; }
    }
}
