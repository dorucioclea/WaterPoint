IF(SELECT COUNT(*) FROM Variant) = 0 BEGIN
    declare @Organizationid int = (select Id from dbo.Organization where name = 'water point')
    declare @size int = (select id from dbo.VariantType where name = 'size')
    declare @colour int = (select id from dbo.VariantType where name = 'colour')
    declare @weight int = (select id from dbo.VariantType where name = 'weight')

    INSERT INTO Variant (VariantTypeId, OrganizationId, Value,[Order]) values (@size, @Organizationid, '6', 1)
    INSERT INTO Variant (VariantTypeId, OrganizationId, Value,[Order]) values (@size, @Organizationid, '7', 2)
    INSERT INTO Variant (VariantTypeId, OrganizationId, Value,[Order]) values (@size, @Organizationid, '8', 3)
    INSERT INTO Variant (VariantTypeId, OrganizationId, Value,[Order]) values (@size, @Organizationid, '9', 4)
    INSERT INTO Variant (VariantTypeId, OrganizationId, Value,[Order]) values (@size, @Organizationid, '10', 5)
    INSERT INTO Variant (VariantTypeId, OrganizationId, Value,[Order]) values (@size, @Organizationid, '11', 6)
    INSERT INTO Variant (VariantTypeId, OrganizationId, Value,[Order]) values (@size, @Organizationid, '12', 7)
    INSERT INTO Variant (VariantTypeId, OrganizationId, Value,[Order]) values (@size, @Organizationid, '13', 8)

    INSERT INTO Variant (VariantTypeId, OrganizationId, Value,DisplayName, [Order]) values (@colour, @Organizationid, 'Red', 'Red', 1)
    INSERT INTO Variant (VariantTypeId, OrganizationId, Value,DisplayName, [Order]) values (@colour, @Organizationid, 'Blue', 'Blue', 2)
    INSERT INTO Variant (VariantTypeId, OrganizationId, Value,DisplayName, [Order]) values (@colour, @Organizationid, 'Green', 'Green', 3)
    INSERT INTO Variant (VariantTypeId, OrganizationId, Value,DisplayName, [Order]) values (@colour, @Organizationid, 'Black', 'Black', 4)    

    INSERT INTO Variant (VariantTypeId, OrganizationId, Value,[Order]) values (@weight, @Organizationid, '1.5kg', 1)
    INSERT INTO Variant (VariantTypeId, OrganizationId, Value,[Order]) values (@weight, @Organizationid, '2.0kg', 2)
    INSERT INTO Variant (VariantTypeId, OrganizationId, Value,[Order]) values (@weight, @Organizationid, '2.5kg', 3)
    INSERT INTO Variant (VariantTypeId, OrganizationId, Value,[Order]) values (@weight, @Organizationid, '3.0kg', 4)    
END
GO