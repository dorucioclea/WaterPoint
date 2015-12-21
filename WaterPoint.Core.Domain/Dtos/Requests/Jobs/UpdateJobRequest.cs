﻿using System.Web.Http.OData;
using WaterPoint.Core.Domain.Dtos.Payloads.Jobs;

namespace WaterPoint.Core.Domain.Dtos.Requests.Jobs
{
    public class UpdateJobRequest : IRequest
    {
        public OrganizationEntityParameter OrganizationEntityParameter { get; set; }
        public Delta<WriteBasicJobDataPayload> UpdateJobPayload { get; set; }
        public int OrganizationUserId { get; set; }
    }
}
