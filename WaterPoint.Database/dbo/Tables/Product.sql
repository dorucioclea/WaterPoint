CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,    
    [ShopId] INT NOT NULL,
    [BrandId] INT NULL,
	[Name] VARCHAR(50) NOT NULL,
    [Description] VARCHAR(200) NULL, 
    [LongDescription] VARCHAR(MAX) NULL, 
    [IsDeleted] BIT NOT NULL DEFAULT(0),
    [IsActive] BIT NOT NULL DEFAULT(1),    
    [UtcCreated] DATETIME2(0) NOT NULL DEFAULT GETUTCDATE(), 
    [UtcUpdated] DATETIME2(0) NOT NULL DEFAULT GETUTCDATE(),
    [Uid] UNIQUEIDENTIFIER NOT NULL DEFAULT(NEWID()),
    CONSTRAINT [FK_Product_Shop] FOREIGN KEY ([ShopId]) REFERENCES [dbo].[Shop]([Id]),
    CONSTRAINT [FK_Product_Brand] FOREIGN KEY ([BrandId]) REFERENCES [dbo].[Brand]([Id])
)
