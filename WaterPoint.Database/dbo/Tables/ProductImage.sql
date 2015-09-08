CREATE TABLE [dbo].[ProductImage]
(    
    ProductId INT NOT NULL,
    ImageId INT NOT NULL,
    IsMain BIT NOT NULL DEFAULT(0),
    IsActive BIT NOT NULL DEFAULT(1),
    [Order] INT NULL,
    CONSTRAINT [FK_ProductImage_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product]([Id]),
    CONSTRAINT [FK_ProductImage_Image] FOREIGN KEY ([ImageId]) REFERENCES [dbo].[Image]([Id]), 
)
