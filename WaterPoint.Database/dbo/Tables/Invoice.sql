CREATE TABLE [dbo].[Invoice]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [OrganizationId] INT NOT NULL,
    [InvoiceTypeId] INT NOT NULL,
    [CustomerId] INT NOT NULL,
    [ContactId] INT NULL,
    [Code] VARCHAR(50) NOT NULL,
    [PaidDate] DATETIME2(0) NULL,
    [DueDate] DATETIME2(0) NULL,
    [IsDraft] BIT NOT NULL DEFAULT(0),
    [IsCancelled] BIT NOT NULL DEFAULT(0),
    [IsFixedPrice] BIT NOT NULL DEFAULT(0),
    [Description] NVARCHAR(MAX) NULL,
    [Version] ROWVERSION NOT NULL,
	[UtcCreated] DATETIME2(0) NOT NULL DEFAULT(GETUTCDATE()),
	[UtcUpdated] DATETIME2(0) NOT NULL DEFAULT(GETUTCDATE()),
	[Uid] UNIQUEIDENTIFIER NOT NULL DEFAULT(NEWID()),
    CONSTRAINT [FK_Invoice_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [dbo].[Organization]([Id]),
    CONSTRAINT [FK_Invoice_InvoiceType] FOREIGN KEY ([InvoiceTypeId]) REFERENCES [dbo].[InvoiceType]([Id]),
    CONSTRAINT [FK_Invoice_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer]([Id]),
    CONSTRAINT [FK_Invoice_Contact] FOREIGN KEY ([ContactId]) REFERENCES [dbo].[Contact]([Id])
)
