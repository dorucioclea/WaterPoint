IF(SELECT COUNT(*) FROM Variant) = 0 BEGIN
    declare @shopid int = (select Id from dbo.shop where name = 'water point')
    INSERT INTO Variant (VariantTypeId, ShopId, Value,[Order]) VALUES (10, @shopid, '6', 1)
    INSERT INTO Variant (VariantTypeId, ShopId, Value,[Order]) VALUES (10, @shopid, '7', 2)
    INSERT INTO Variant (VariantTypeId, ShopId, Value,[Order]) VALUES (10, @shopid, '8', 3)
    INSERT INTO Variant (VariantTypeId, ShopId, Value,[Order]) VALUES (10, @shopid, '9', 4)
    INSERT INTO Variant (VariantTypeId, ShopId, Value,[Order]) VALUES (10, @shopid, '10', 5)
    INSERT INTO Variant (VariantTypeId, ShopId, Value,[Order]) VALUES (10, @shopid, '11', 6)
    INSERT INTO Variant (VariantTypeId, ShopId, Value,[Order]) VALUES (10, @shopid, '12', 7)
    INSERT INTO Variant (VariantTypeId, ShopId, Value,[Order]) VALUES (10, @shopid, '13', 8)

    INSERT INTO Variant (VariantTypeId, ShopId, Value,DisplayName, [Order]) VALUES (11, @shopid, 'Red', 'Red', 1)
    INSERT INTO Variant (VariantTypeId, ShopId, Value,DisplayName, [Order]) VALUES (11, @shopid, 'Blue', 'Blue', 2)
    INSERT INTO Variant (VariantTypeId, ShopId, Value,DisplayName, [Order]) VALUES (11, @shopid, 'Green', 'Green', 3)
    INSERT INTO Variant (VariantTypeId, ShopId, Value,DisplayName, [Order]) VALUES (11, @shopid, 'Black', 'Black', 4)    

    INSERT INTO Variant (VariantTypeId, ShopId, Value,[Order]) VALUES (12, @shopid, '1.5kg', 1)
    INSERT INTO Variant (VariantTypeId, ShopId, Value,[Order]) VALUES (12, @shopid, '2.0kg', 2)
    INSERT INTO Variant (VariantTypeId, ShopId, Value,[Order]) VALUES (12, @shopid, '2.5kg', 3)
    INSERT INTO Variant (VariantTypeId, ShopId, Value,[Order]) VALUES (12, @shopid, '3.0kg', 4)    
END
GO