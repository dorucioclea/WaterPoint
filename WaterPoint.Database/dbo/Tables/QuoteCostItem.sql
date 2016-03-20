CREATE TABLE [dbo].[QuoteCostItem]
(
    [Id] INT NOT NULL IDENTITY,
    [QuoteId] INT NOT NULL,
    [LastChangeOrganizationUserId] INT NULL,
    [CostItemId] INT NOT NULL,
    [IsWriteOff] BIT NOT NULL DEFAULT(0),
    [ShortDescription] NVARCHAR(200) NOT NULL,
    [LongDescription] NVARCHAR(MAX) NULL,
    [UnitCost] DECIMAL(10,3) NOT NULL DEFAULT(0),
    [UnitPrice] DECIMAL(10,3) NOT NULL DEFAULT(0),
    [TotalPrice] DECIMAL(10,3) NOT NULL DEFAULT(0),
    [Quantity] DECIMAL(8,2) NOT NULL DEFAULT(0),
    [IsBillable] BIT NOT NULL DEFAULT(1),
    [IsDeleted] BIT NOT NULL DEFAULT(0),
    [Version] ROWVERSION NOT NULL,
	[UtcCreated] DATETIME2(3) NOT NULL DEFAULT(SYSUTCDATETIME()),
	[UtcUpdated] DATETIME2(3) NOT NULL DEFAULT(SYSUTCDATETIME()),
    [Uid] UNIQUEIDENTIFIER NOT NULL DEFAULT(NEWID()),
    CONSTRAINT [PK_dbo_QuoteCostItem_Id] PRIMARY KEY CLUSTERED (Id ASC),
    CONSTRAINT [FK_dbo_QuoteJobCostItem_dbo_Quote] FOREIGN KEY ([QuoteId]) REFERENCES [dbo].[Quote]([Id]),
    CONSTRAINT [FK_dbo_QuoteJobCostItem_dbo_JobCostItem] FOREIGN KEY ([CostItemId]) REFERENCES [dbo].[CostItem]([Id]),
    CONSTRAINT [FK_dbo_QuoteJobCostItem_dbo_OrganizationUser] FOREIGN KEY ([LastChangeOrganizationUserId]) REFERENCES [dbo].[OrganizationUser]([Id])
)
