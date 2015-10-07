IF(NOT EXISTS(SELECT TOP 1 * FROM im.Product))
    BEGIN
        DBCC checkident ('im.Product', reseed, 10000)
    END

IF(NOT EXISTS(SELECT TOP 1 * FROM im.Category))
    BEGIN
        DBCC checkident ('im.Category', reseed, 1000)
    END

IF(NOT EXISTS(SELECT TOP 1 * FROM im.Brand))
    BEGIN
        DBCC checkident ('im.Brand', reseed, 100)
    END

IF(NOT EXISTS(SELECT TOP 1 * FROM dbo.Customer))
    BEGIN
        DBCC checkident ('dbo.Customer', reseed, 10000)
    END

IF(NOT EXISTS(SELECT TOP 1 * FROM im.Sku))
    BEGIN
        DBCC checkident ('im.Sku', reseed, 10000)
    END

IF(NOT EXISTS(SELECT TOP 1 * FROM im.Flag))
    BEGIN
        DBCC checkident ('im.Flag', reseed, 10)
    END

IF(NOT EXISTS(SELECT TOP 1 * FROM im.VariantType))
    BEGIN
        DBCC checkident ('im.VariantType', reseed, 10)
    END

IF(NOT EXISTS(SELECT TOP 1 * FROM dbo.Organization))
    BEGIN
        DBCC checkident ('dbo.Organization', reseed, 1000)
    END

IF(NOT EXISTS(SELECT TOP 1 * FROM dbo.Branch))
    BEGIN
        DBCC checkident ('dbo.Branch', reseed, 100)
    END
GO
