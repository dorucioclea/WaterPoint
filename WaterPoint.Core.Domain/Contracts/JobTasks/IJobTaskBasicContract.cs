﻿using System;

namespace WaterPoint.Core.Domain.Contracts.JobTasks
{
    public interface IJobTaskBasicContract : IContract
    {
        int OrganizationId { get; set; }
        DateTime? CompletedDate { get; set; }
        DateTime? EndDate { get; set; }
        int? EstimatedTimeInMinutes { get; set; }
        int Id { get; set; }
        bool IsBillable { get; set; }
        bool IsCompleted { get; set; }
        int JobId { get; set; }
        string ShortDescription { get; set; }
        DateTime? StartDate { get; set; }
        int TaskDefinitionId { get; set; }
        string Uid { get; set; }
        string Version { get; set; }
    }
}
