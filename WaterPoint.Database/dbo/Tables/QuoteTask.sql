CREATE TABLE [dbo].[QuoteJobTask]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [QuoteId] INT NOT NULL,
    [TaskId] INT NOT NULL,
    [DisplayOrder] INT NOT NULL,
    [EstimatedTimeInMinutes] INT NOT NULL,
    [StartDate] DATETIME2(0) NULL,
    [EndDate] DATETIME2(0) NULL,
    [CompletedDate] DATETIME2(0) NULL,
    [IsBillable] BIT NOT NULL DEFAULT(1),
    [IsCompleted] BIT NOT NULL DEFAULT(0),
    [IsAllocated] BIT NOT NULL DEFAULT(0),
    [IsScheduled] BIT NOT NULL DEFAULT(0),
    [ShortDescription] NVARCHAR (100) NULL,
    [LongDescription] NVARCHAR (MAX) NULL,
	[UtcCreated] DATETIME2(0) NOT NULL DEFAULT(GETUTCDATE()),
	[UtcUpdated] DATETIME2(0) NOT NULL DEFAULT(GETUTCDATE()),
    [Uid] UNIQUEIDENTIFIER NOT NULL DEFAULT(NEWID())
    CONSTRAINT [FK_QuoteJobTask_Quote] FOREIGN KEY ([QuoteId]) REFERENCES [dbo].[Quote]([Id]),
    CONSTRAINT [FK_QuoteJobTask_JobTask] FOREIGN KEY ([TaskId]) REFERENCES [dbo].[Task]([Id])
)
