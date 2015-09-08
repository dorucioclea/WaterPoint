CREATE TABLE [dbo].[CategoryImage]
(    
    CategoryId INT NOT NULL,
    ImageId INT NOT NULL,
    IsMain BIT NOT NULL DEFAULT(0),
    IsActive BIT NOT NULL DEFAULT(1),
    [Order] INT NULL,
    CONSTRAINT [FK_CategoryImage_Product] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category]([Id]),
    CONSTRAINT [FK_CategoryImage_Image] FOREIGN KEY ([ImageId]) REFERENCES [dbo].[Image]([Id]), 
)
