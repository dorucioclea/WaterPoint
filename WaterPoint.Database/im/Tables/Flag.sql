CREATE TABLE [im].[Flag]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [OrganizationId] INT NOT NULL,
    [Name] VARCHAR(15) NOT NULL,
    CONSTRAINT [FK_Flag_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [dbo].[Organization]([Id]),
)
