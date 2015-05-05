﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WaterPoint.Api.Domain.Services;
using WaterPoint.Core.ContractMapper;
using WaterPoint.Core.Domain.Bll;
using WaterPoint.Core.Contract;
using WaterPoint.Data.Entity;

namespace WaterPoint.Api.Service
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

            var result = CoreMapperHelper.Map<Organization, OrganizationContract>(org);

            return result;
        }
    }
}