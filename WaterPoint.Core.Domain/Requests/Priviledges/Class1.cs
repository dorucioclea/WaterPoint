using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Core.Domain.Requests.Priviledges
{
    public class ListUserPrivilegesRequest : IRequest
    {
        public string OrganizationUserIds { get; set; }
    }
}
