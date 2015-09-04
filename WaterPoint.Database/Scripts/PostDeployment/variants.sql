IF(SELECT COUNT(*) FROM Variant) = 0 BEGIN
    INSERT INTO Variant (VariantTypeId, Value, [Order]) VALUES (10, '6', 1)
    INSERT INTO Variant (VariantTypeId, Value, [Order]) VALUES (10, '7', 2)
    INSERT INTO Variant (VariantTypeId, Value, [Order]) VALUES (10, '8', 3)
    INSERT INTO Variant (VariantTypeId, Value, [Order]) VALUES (10, '9', 4)
    INSERT INTO Variant (VariantTypeId, Value, [Order]) VALUES (10, '10', 5)
    INSERT INTO Variant (VariantTypeId, Value, [Order]) VALUES (10, '11', 6)
    INSERT INTO Variant (VariantTypeId, Value, [Order]) VALUES (10, '12', 7)
    INSERT INTO Variant (VariantTypeId, Value, [Order]) VALUES (10, '13', 8)

    INSERT INTO Variant (VariantTypeId, Value, DisplayName, [Order]) VALUES (11, 'Red', 'Red', 1)
    INSERT INTO Variant (VariantTypeId, Value, DisplayName, [Order]) VALUES (11, 'Blue', 'Blue', 2)
    INSERT INTO Variant (VariantTypeId, Value, DisplayName, [Order]) VALUES (11, 'Green', 'Green', 3)
    INSERT INTO Variant (VariantTypeId, Value, DisplayName, [Order]) VALUES (11, 'Black', 'Black', 4)    

    INSERT INTO Variant (VariantTypeId, Value, [Order]) VALUES (12, '1.5kg', 1)
    INSERT INTO Variant (VariantTypeId, Value, [Order]) VALUES (12, '2.0kg', 2)
    INSERT INTO Variant (VariantTypeId, Value, [Order]) VALUES (12, '2.5kg', 3)
    INSERT INTO Variant (VariantTypeId, Value, [Order]) VALUES (12, '3.0kg', 4)    
END
GO