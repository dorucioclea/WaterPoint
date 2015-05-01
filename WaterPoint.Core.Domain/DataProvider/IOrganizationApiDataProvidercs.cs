using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Contract;

namespace WaterPoint.Core.Domain.DataProvider
{
    public interface IOrganizationApiDataProvider
    {
        Task<OrganizationContract> GetByIdAsync(int id);
    }
}
