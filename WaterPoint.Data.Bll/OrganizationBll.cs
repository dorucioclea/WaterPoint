using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain.Bll;
using WaterPoint.Data.Entity;
using WaterPoint.Data.Repository;
using WaterPoint.Data.Repository.Interfaces;

namespace WaterPoint.Data.Bll
{
    public class OrganizationBll : IOrganizationBll
    {
        private readonly OrganizationRepository _organizationRepo;

        public OrganizationBll(OrganizationRepository organizationRepo)
        {
            _organizationRepo = organizationRepo;
        }

        public async Task<Organization> GetAsync(int organizationId)
        {
            var organization = await _organizationRepo.GetAsync(organizationId);

            return organization;
        }
    }
}
