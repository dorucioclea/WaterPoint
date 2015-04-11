using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Api.DataContract;

namespace WaterPoint.Data.Service.Interfaces
{
    public interface IOrganizationService
    {
        Task<OrganizationContract> GetByIdAsync(int organizationId);
    }
}
