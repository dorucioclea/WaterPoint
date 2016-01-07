CREATE TABLE [dbo].[InvoiceJobTask]
(
    [Id] INT NOT NULL IDENTITY,
    [InvoiceId] INT NOT NULL,
    [JobTaskId] INT NOT NULL,
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
    CONSTRAINT [PK_dbo_InvoiceJobTask_Id] PRIMARY KEY CLUSTERED (Id ASC),
    CONSTRAINT [FK_InvoiceJobTask_Invoice] FOREIGN KEY ([InvoiceId]) REFERENCES [dbo].[Invoice]([Id]),
    CONSTRAINT [FK_InvoiceJobTask_JobTask] FOREIGN KEY ([JobTaskId]) REFERENCES [dbo].[JobTask]([Id])
)
