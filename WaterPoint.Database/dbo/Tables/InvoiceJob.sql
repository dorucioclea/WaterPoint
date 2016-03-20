CREATE TABLE [dbo].[InvoiceJob]
(
    [Id] INT NOT NULL IDENTITY,
    [InvoiceId] INT NOT NULL,
    [JobId] INT NOT NULL,
    [LastChangeOrganizationUserId] INT NULL,
    [Description] NVARCHAR(MAX),
    [Version] ROWVERSION NOT NULL,
	[UtcCreated] DATETIME2(3) NOT NULL DEFAULT(SYSUTCDATETIME()),
	[UtcUpdated] DATETIME2(3) NOT NULL DEFAULT(SYSUTCDATETIME()),
	[Uid] UNIQUEIDENTIFIER NOT NULL DEFAULT(NEWID()),
    CONSTRAINT [PK_dbo_InvoiceJob] PRIMARY KEY CLUSTERED (Id ASC),
    CONSTRAINT [FK_dbo_InvoiceJob_dbo_Job] FOREIGN KEY ([JobId]) REFERENCES [dbo].[Job]([Id]),
    CONSTRAINT [FK_dbo_InvoiceJob_dbo_Invoice] FOREIGN KEY ([InvoiceId]) REFERENCES [dbo].[Invoice]([Id]),
    CONSTRAINT [FK_dbo_InvoiceJob_dbo_OrganizationUser] FOREIGN KEY ([LastChangeOrganizationUserId]) REFERENCES [dbo].[OrganizationUser]([Id])
)
