CREATE TABLE [dbo].[InvoiceJobTask]
(
    [Id] INT NOT NULL IDENTITY,
    [InvoiceId] INT NOT NULL,
    [JobTaskId] INT NOT NULL,
    [ShortDescription] NVARCHAR(200) NOT NULL,
    [LongDescription] NVARCHAR(MAX) NULL,
    [IsBillable] BIT NOT NULL DEFAULT(1),
    [Version] ROWVERSION NOT NULL,
	[UtcCreated] DATETIME2(3) NOT NULL DEFAULT(SYSUTCDATETIME()),
	[UtcUpdated] DATETIME2(3) NOT NULL DEFAULT(SYSUTCDATETIME()),
    [Uid] UNIQUEIDENTIFIER NOT NULL DEFAULT(NEWID()),
    CONSTRAINT [PK_dbo_InvoiceJobTask_Id] PRIMARY KEY CLUSTERED (Id ASC),
    CONSTRAINT [FK_InvoiceJobTask_Invoice] FOREIGN KEY ([InvoiceId]) REFERENCES [dbo].[Invoice]([Id]),
    CONSTRAINT [FK_InvoiceJobTask_JobTask] FOREIGN KEY ([JobTaskId]) REFERENCES [dbo].[JobTask]([Id])
)
