using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Api.Contract;
using WaterPoint.Data.Bll.Interfaces;
using WaterPoint.Data.Entity;
using WaterPoint.Data.Service.Interfaces;
using AutoMapper;
using WaterPoint.Api.DataContract;

namespace WaterPoint.Data.Service
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationBll _organizationBll;

        public OrganizationService(IOrganizationBll organizationBll)
        {
            _organizationBll = organizationBll;
        }

        public async Task<OrganizationContract> GetByIdAsync(int organizationId)
        {
            var org = await _organizationBll.GetAsync(organizationId);

            var result = Mapper.Map<OrganizationContract>(org);

            return result;
        }
    }
}
