CREATE TABLE [im].[BrandImage]
(
    BrandId INT NOT NULL,
    ImageId INT NOT NULL,
    IsMain BIT NOT NULL DEFAULT(0),
    IsActive BIT NOT NULL DEFAULT(1),
    [Order] INT NULL,
    CONSTRAINT [FK_BrandImage_Product] FOREIGN KEY ([BrandId]) REFERENCES [im].[Brand]([Id]),
    CONSTRAINT [FK_BrandImage_Image] FOREIGN KEY ([ImageId]) REFERENCES [dbo].[Image]([Id]),
)
