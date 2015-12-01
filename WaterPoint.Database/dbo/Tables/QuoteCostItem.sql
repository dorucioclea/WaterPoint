CREATE TABLE [dbo].[QuoteCostItem]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [QuoteId] INT NOT NULL,
    [CostItemId] INT NOT NULL,
    [ShortDescription] NVARCHAR(200) NOT NULL,
    [LongDescription] NVARCHAR(MAX) NULL,
    [UnitCost] DECIMAL(10,3) NOT NULL DEFAULT(0),
    [UnitPrice] DECIMAL(10,3) NOT NULL DEFAULT(0),
    [TotalPrice] DECIMAL(10,3) NOT NULL DEFAULT(0),
    [Quantity] DECIMAL(8,2) NOT NULL DEFAULT(0),
    [IsBillable] BIT NOT NULL DEFAULT(1),
	[UtcCreated] DATETIME2(0) NOT NULL DEFAULT(GETUTCDATE()),
	[UtcUpdated] DATETIME2(0) NOT NULL DEFAULT(GETUTCDATE()),
    [Uid] UNIQUEIDENTIFIER NOT NULL DEFAULT(NEWID()),
    CONSTRAINT [FK_QuoteJobCostItem_Quote] FOREIGN KEY ([QuoteId]) REFERENCES [dbo].[Quote]([Id]),
    CONSTRAINT [FK_QuoteJobCostItem_JobCostItem] FOREIGN KEY ([CostItemId]) REFERENCES [dbo].[CostItem]([Id]),
)
