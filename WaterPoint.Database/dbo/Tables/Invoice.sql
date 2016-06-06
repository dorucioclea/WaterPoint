﻿CREATE TABLE [dbo].[Invoice]
(
    [Id] INT NOT NULL IDENTITY,
    [OrganizationId] INT NOT NULL,
    [LastChangeOrganizationUserId] INT NULL,
    [InvoiceTypeId] INT NOT NULL,
    [InvoiceStatusId] INT NOT NULL,
    [CustomerId] INT NOT NULL,
    [ContactId] INT NULL,
    [Code] VARCHAR(50) NOT NULL,
    [PaidDate] DATETIME2(0) NULL,
    [DueDate] DATETIME2(0) NULL,
    [TotalPrice] DECIMAL(10,3) DEFAULT(0),
    [TotalPriceWithTax] DECIMAL(10,3) DEFAULT(0),
    [ShortDescription] NVARCHAR(200) NOT NULL,
    [LongDescription] NVARCHAR(MAX) NULL,
    [Version] ROWVERSION NOT NULL,
	[UtcCreated] DATETIME2(3) NOT NULL DEFAULT(SYSUTCDATETIME()),
	[UtcUpdated] DATETIME2(3) NOT NULL DEFAULT(SYSUTCDATETIME()),
	[Uid] UNIQUEIDENTIFIER NOT NULL DEFAULT(NEWID()),
    CONSTRAINT [PK_dbo_Invoice] PRIMARY KEY CLUSTERED (Id ASC),
    CONSTRAINT [FK_dbo_Invoice_dbo_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [dbo].[Organization]([Id]),
    CONSTRAINT [FK_dbo_Invoice_dbo_InvoiceType] FOREIGN KEY ([InvoiceTypeId]) REFERENCES [dbo].[InvoiceType]([Id]),
    CONSTRAINT [FK_dbo_Invoice_dbo_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer]([Id]),
    CONSTRAINT [FK_dbo_Invoice_dbo_Contact] FOREIGN KEY ([ContactId]) REFERENCES [dbo].[Contact]([Id]),
    CONSTRAINT [FK_dbo_Invoice_dbo_InvoiceStatus] FOREIGN KEY ([InvoiceStatusId]) REFERENCES [dbo].[InvoiceStatus]([Id]),
    CONSTRAINT [FK_dbo_Invoice_dbo_OrganizationUser] FOREIGN KEY ([LastChangeOrganizationUserId]) REFERENCES [dbo].[OrganizationUser]([Id])
)
