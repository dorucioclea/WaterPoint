﻿using WaterPoint.Core.Domain.Payloads.TaskDefinitions;

namespace WaterPoint.Core.Domain.Requests.TaskDefinitions
{
    public class CreateTaskDefinitionRequest : ICreateRequest<WriteTaskDefinitionPayload>
    {
        public int OrganizationId { get; set; }
        public WriteTaskDefinitionPayload Payload { get; set; }
        public int OrganizationUserId { get; set; }
    }
}
