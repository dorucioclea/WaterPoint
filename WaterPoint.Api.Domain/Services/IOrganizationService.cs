using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Contract;

namespace WaterPoint.Core.Domain.Services
{
    public interface IOrganizationService
    {
        Task<OrganizationContract> GetByIdAsync(int organizationId);
    }
}
