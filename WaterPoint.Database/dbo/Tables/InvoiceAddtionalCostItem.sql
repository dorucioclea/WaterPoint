CREATE TABLE [dbo].[InvoiceAdditonalCostItem]
(
    [Id] INT NOT NULL IDENTITY,
    [InvoiceId] INT NOT NULL,
    [CostItemId] INT NOT NULL,
    [ShortDescription] NVARCHAR(200) NOT NULL,
    [LongDescription] NVARCHAR(MAX) NULL,
    [UnitCost] DECIMAL(10,3) NOT NULL DEFAULT(0),
    [UnitPrice] DECIMAL(10,3) NOT NULL DEFAULT(0),
    [Quantity] DECIMAL(8,2) NOT NULL DEFAULT(0),
    [IsBillable] BIT NOT NULL DEFAULT(1),
    [Version] ROWVERSION NOT NULL,
	[UtcCreated] DATETIME2(3) NOT NULL DEFAULT(SYSUTCDATETIME()),
	[UtcUpdated] DATETIME2(3) NOT NULL DEFAULT(SYSUTCDATETIME()),
    [Uid] UNIQUEIDENTIFIER NOT NULL DEFAULT(NEWID()),
    CONSTRAINT [PK_dbo_InvoiceAddtionalCostItem] PRIMARY KEY CLUSTERED (Id ASC),
    CONSTRAINT [FK_InvoiceAddtionalCostItem_Invoice] FOREIGN KEY ([InvoiceId]) REFERENCES [dbo].[Invoice]([Id]),
    CONSTRAINT [FK_InvoiceAddtionalCostItem_CostItem] FOREIGN KEY ([CostItemId]) REFERENCES [dbo].[CostItem]([Id]),
)
