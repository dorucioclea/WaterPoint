CREATE TABLE [dbo].[InvoiceJobTask]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [InvoiceId] INT NOT NULL,
    [JobTaskId] INT NOT NULL,
    [ShortDescription] NVARCHAR(200) NOT NULL,
    [LongDescription] NVARCHAR(MAX) NULL,
    [IsBillable] BIT NOT NULL DEFAULT(1),
	[UtcCreated] DATETIME2(0) NOT NULL DEFAULT(GETUTCDATE()),
	[UtcUpdated] DATETIME2(0) NOT NULL DEFAULT(GETUTCDATE()),
    [Uid] UNIQUEIDENTIFIER NOT NULL DEFAULT(NEWID()),
    CONSTRAINT [FK_InvoiceJobTask_Invoice] FOREIGN KEY ([InvoiceId]) REFERENCES [dbo].[Invoice]([Id]),
    CONSTRAINT [FK_InvoiceJobTask_JobTask] FOREIGN KEY ([JobTaskId]) REFERENCES [dbo].[JobTask]([Id])
)
