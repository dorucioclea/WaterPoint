﻿CREATE TABLE [dbo].[QuoteTask]
(
    [Id] INT NOT NULL IDENTITY,
    [QuoteId] INT NOT NULL,
    [TaskDefinitionId] INT NOT NULL,
    [DisplayOrder] INT NULL,
    [EstimatedTimeInMinutes] INT NOT NULL,
    [StartDate] DATETIME2(0) NULL,
    [EndDate] DATETIME2(0) NULL,
    [CompletedDate] DATETIME2(0) NULL,
    [IsBillable] BIT NOT NULL DEFAULT(1),
    [IsCompleted] BIT NOT NULL DEFAULT(0),
    [BaseRate] DECIMAL(10,3) NOT NULL DEFAULT(0),
    [BillableRate] DECIMAL(10,3) NOT NULL DEFAULT(0),
    [ShortDescription] NVARCHAR (100) NULL,
    [LongDescription] NVARCHAR (MAX) NULL,
    [Version] ROWVERSION NOT NULL,
	[UtcCreated] DATETIME2(3) NOT NULL DEFAULT(SYSUTCDATETIME()),
	[UtcUpdated] DATETIME2(3) NOT NULL DEFAULT(SYSUTCDATETIME()),
    [Uid] UNIQUEIDENTIFIER NOT NULL DEFAULT(NEWID()),
    CONSTRAINT [PK_dbo_QuoteTask_Id] PRIMARY KEY CLUSTERED (Id ASC),
    CONSTRAINT [FK_dbo_QuoteTask_dbo_Quote] FOREIGN KEY ([QuoteId]) REFERENCES [dbo].[Quote]([Id]),
    CONSTRAINT [FK_dbo_QuoteTask_dbo_TaskDefinition] FOREIGN KEY ([TaskDefinitionId]) REFERENCES [dbo].[TaskDefinition]([Id])
)
