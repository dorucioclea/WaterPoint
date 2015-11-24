using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain.Dtos.Interfaces;

namespace WaterPoint.Core.Domain.Dtos.Requests.Jobs
{
    public class GetJobByIdRequest: IOrganizationEntityParameter, IRequest
    {
        public OrganizationEntityParameter OrganizationEntityParameter { get; set; }
    }
}
