﻿using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.Jobs
{
    public class GetJob : IQueryParameter
    {
        public int OrganizationId { get; set; }
        public int JobId { get; set; }
    }
}
