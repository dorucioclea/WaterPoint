﻿using WaterPoint.Core.Domain.Payloads.JobCostItems;
using WaterPoint.Core.Domain.Payloads.Jobs;
using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.JobCostItems
{
    public class CreateJobCostItemRequest : IRequest
    {
        public OrgIdJobIdRp Parameter { get; set; }

        public WriteJobCostItemPayload Payload { get; set; }

        public int OrganizationUserId { get; set; }
    }
}
