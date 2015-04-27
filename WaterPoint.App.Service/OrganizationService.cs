using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.App.Domain.Services;
using WaterPoint.Core.Domain.DataProvider;

namespace WaterPoint.App.Service
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationApiDataProvider _organizationApiDataProvider;

        public OrganizationService(IOrganizationApiDataProvider organizationApiDataProvider)
        {
            _organizationApiDataProvider = organizationApiDataProvider;
        }
    }
}
