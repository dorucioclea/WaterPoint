IF(SELECT COUNT(*) FROM dbo.Product) = 0
    BEGIN
        DBCC checkident ('dbo.Product', reseed, 10000)
    END

IF(SELECT COUNT(*) FROM dbo.Category) = 0
    BEGIN
        DBCC checkident ('dbo.Category', reseed, 1000)
    END

IF(SELECT COUNT(*) FROM dbo.Customer) = 0
    BEGIN
        DBCC checkident ('dbo.Customer', reseed, 10000)
    END

IF(SELECT COUNT(*) FROM dbo.Sku) = 0
    BEGIN
        DBCC checkident ('dbo.Sku', reseed, 10000)
    END

IF(SELECT COUNT(*) FROM dbo.Flag) = 0
    BEGIN
        DBCC checkident ('dbo.Flag', reseed, 10)
    END

IF(SELECT COUNT(*) FROM dbo.VariantType) = 0
    BEGIN
        DBCC checkident ('dbo.VariantType', reseed, 10)
    END

IF(SELECT COUNT(*) FROM dbo.Shop) = 0
    BEGIN
        DBCC checkident ('dbo.Shop', reseed, 1000)
    END

IF(SELECT COUNT(*) FROM dbo.Branch) = 0
    BEGIN
        DBCC checkident ('dbo.Branch', reseed, 100)
    END
GO