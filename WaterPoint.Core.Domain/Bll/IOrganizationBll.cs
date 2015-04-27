using System.Collections.Generic;
using System.Threading.Tasks;
using WaterPoint.Data.Entity;

namespace WaterPoint.Core.Domain.Bll
{
    public interface IOrganizationBll
    {
        Task<Organization> GetAsync(int organizationId);
    }
}