CREATE TABLE [dbo].[CostItem]
(
    [Id] INT NOT NULL IDENTITY,
    [OrganizationId] INT NOT NULL,
    [CostItemTypeId] INT NOT NULL,
	[UnitOfMeasurementId] INT NOT NULL DEFAULT(1),
    [SupplierId] INT NULL,
    [ShortDescription] NVARCHAR(200) NOT NULL,
    [LongDescription] NVARCHAR(MAX) NULL,
    [Code] VARCHAR(50) NULL,
    [UnitCost] DECIMAL(10,3) NOT NULL DEFAULT(0),
    [UnitPrice] DECIMAL(10,3) NOT NULL DEFAULT(0),
    [IsBillable] BIT NOT NULL DEFAULT(1),
    [IsDeleted] BIT NOT NULL DEFAULT(0),
    [UtcCreated] DATETIME2(3) NOT NULL DEFAULT(SYSUTCDATETIME()),
	[UtcUpdated] DATETIME2(3) NOT NULL DEFAULT(SYSUTCDATETIME()),
    [Version] ROWVERSION NOT NULL,
    [Uid] UNIQUEIDENTIFIER NOT NULL DEFAULT(NEWID()),
    CONSTRAINT [PK_dbo_CostItem_Id] PRIMARY KEY CLUSTERED (Id ASC),
    CONSTRAINT [FK_dbo_CostItem_dbo_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [dbo].[Organization]([Id]),
    CONSTRAINT [FK_dbo_CostItem_dbo_Supplier] FOREIGN KEY ([SupplierId]) REFERENCES [dbo].[Supplier]([Id]),
    CONSTRAINT [FK_dbo_CostItemT_dbo_CostItemType] FOREIGN KEY ([CostItemTypeId]) REFERENCES [dbo].[CostItemType]([Id])
)
