using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.App.Domain.Services;
using WaterPoint.App.ViewModel;
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

        public async Task<OrganizationIndex> OrganizationIndex(int id)
        {
            var result = new OrganizationIndex();

            var contract = await _organizationApiDataProvider.GetByIdAsync(id);

            //TODO: mapper

            return result;
        }
    }
}
