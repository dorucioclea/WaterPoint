﻿CREATE TABLE [dbo].[JobTask]
(
    [Id] INT NOT NULL IDENTITY,
    [JobId] INT NOT NULL,
    [TaskDefinitionId] INT NOT NULL,
    [DisplayOrder] INT NOT NULL DEFAULT(9999),
    [EstimatedTimeInMinutes] INT NULL,
    [StartDate] DATETIME2(0) NULL,
    [EndDate] DATETIME2(0) NULL,
    [CompletedDate] DATETIME2(0) NULL,
    [BaseRate] DECIMAL(10,3) NOT NULL DEFAULT(0),
    [BillableRate] DECIMAL(10,3) NOT NULL DEFAULT(0),
    [IsBillable] BIT NOT NULL DEFAULT(1),
    [IsCompleted] BIT NOT NULL DEFAULT(0),
    [IsAllocated] BIT NOT NULL DEFAULT(0),
    [IsScheduled] BIT NOT NULL DEFAULT(0),
    [IsDeleted] BIT NOT NULL DEFAULT(0),
    [ShortDescription] NVARCHAR (200) NULL,
    [LongDescription] NVARCHAR (MAX) NULL,
    [Version] ROWVERSION NOT NULL,
	[UtcCreated] DATETIME2(3) NOT NULL DEFAULT(SYSUTCDATETIME()),
	[UtcUpdated] DATETIME2(3) NOT NULL DEFAULT(SYSUTCDATETIME()),
    [Uid] UNIQUEIDENTIFIER NOT NULL DEFAULT(NEWID()),
    CONSTRAINT [PK_dbo_JobTask_Id] PRIMARY KEY CLUSTERED (Id ASC),
    CONSTRAINT [FK_JobTask_Job] FOREIGN KEY ([JobId]) REFERENCES [dbo].[Job]([Id]),
    CONSTRAINT [FK_JobTask_Task] FOREIGN KEY ([TaskDefinitionId]) REFERENCES [dbo].[TaskDefinition]([Id])
)
