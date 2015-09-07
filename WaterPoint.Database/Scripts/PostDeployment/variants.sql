IF(SELECT COUNT(*) FROM Variant) = 0 BEGIN
    declare @shopid int = (select Id from dbo.shop where name = 'water point')
    declare @size int = (select id from dbo.VariantType where name = 'size')
    declare @colour int = (select id from dbo.VariantType where name = 'colour')
    declare @weight int = (select id from dbo.VariantType where name = 'weight')

    INSERT INTO Variant (VariantTypeId, ShopId, Value,[Order]) values (@size, @shopid, '6', 1)
    INSERT INTO Variant (VariantTypeId, ShopId, Value,[Order]) values (@size, @shopid, '7', 2)
    INSERT INTO Variant (VariantTypeId, ShopId, Value,[Order]) values (@size, @shopid, '8', 3)
    INSERT INTO Variant (VariantTypeId, ShopId, Value,[Order]) values (@size, @shopid, '9', 4)
    INSERT INTO Variant (VariantTypeId, ShopId, Value,[Order]) values (@size, @shopid, '10', 5)
    INSERT INTO Variant (VariantTypeId, ShopId, Value,[Order]) values (@size, @shopid, '11', 6)
    INSERT INTO Variant (VariantTypeId, ShopId, Value,[Order]) values (@size, @shopid, '12', 7)
    INSERT INTO Variant (VariantTypeId, ShopId, Value,[Order]) values (@size, @shopid, '13', 8)

    INSERT INTO Variant (VariantTypeId, ShopId, Value,DisplayName, [Order]) values (@colour, @shopid, 'Red', 'Red', 1)
    INSERT INTO Variant (VariantTypeId, ShopId, Value,DisplayName, [Order]) values (@colour, @shopid, 'Blue', 'Blue', 2)
    INSERT INTO Variant (VariantTypeId, ShopId, Value,DisplayName, [Order]) values (@colour, @shopid, 'Green', 'Green', 3)
    INSERT INTO Variant (VariantTypeId, ShopId, Value,DisplayName, [Order]) values (@colour, @shopid, 'Black', 'Black', 4)    

    INSERT INTO Variant (VariantTypeId, ShopId, Value,[Order]) values (@weight, @shopid, '1.5kg', 1)
    INSERT INTO Variant (VariantTypeId, ShopId, Value,[Order]) values (@weight, @shopid, '2.0kg', 2)
    INSERT INTO Variant (VariantTypeId, ShopId, Value,[Order]) values (@weight, @shopid, '2.5kg', 3)
    INSERT INTO Variant (VariantTypeId, ShopId, Value,[Order]) values (@weight, @shopid, '3.0kg', 4)    
END
GO