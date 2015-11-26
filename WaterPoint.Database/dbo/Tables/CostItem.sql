CREATE TABLE [dbo].[CostItem]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [OrganizationId] INT NOT NULL,
    [SupplierId] INT NULL,
    [ShortDescription] NVARCHAR(200) NOT NULL,
    [LongDescription] NVARCHAR(MAX) NULL,
    [Code] VARCHAR(50) NULL,
    [UnitCost] DECIMAL(10,3) NOT NULL DEFAULT(0),
    [UnitPrice] DECIMAL(10,3) NOT NULL DEFAULT(0),
    [IsBillable] BIT NOT NULL DEFAULT(1),
    [UtcCreated] DATETIME2(0) NOT NULL DEFAULT(GETUTCDATE()),
	[UtcUpdated] DATETIME2(0) NOT NULL DEFAULT(GETUTCDATE()),
    [Uid] UNIQUEIDENTIFIER NOT NULL DEFAULT(NEWID()),
    CONSTRAINT [FK_CostItem_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [dbo].[Organization]([Id]),
    CONSTRAINT [FK_CostItem_Supplier] FOREIGN KEY ([SupplierId]) REFERENCES [dbo].[Supplier]([Id]),
)
