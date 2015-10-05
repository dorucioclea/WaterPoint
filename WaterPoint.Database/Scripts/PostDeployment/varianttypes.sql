--MERGE INTO dbo.VariantType AS T
--USING 
--(
--	SELECT 10 AS Id, 'Size' AS Name
--	UNION ALL
--	SELECT 11 AS Id, 'Colour' AS Name
--    UNION ALL
--	SELECT 12 AS Id, 'Weight' AS Name
--) AS S 

--ON 
--	T.Id = S.Id

--WHEN MATCHED THEN 
--	UPDATE SET Name = S.Name

--WHEN NOT MATCHED BY TARGET THEN 
--	INSERT (Id, Name) 
--    VALUES (S.Id, S.Name)

--WHEN NOT MATCHED BY SOURCE THEN
--	DELETE;
--GO

if(select count(*) from VariantType) = 0 begin
    declare @Organizationid int = (select Id from dbo.Organization where name = 'water point')
    insert into VariantType (Name, OrganizationId) values ('Size', @Organizationid)
    insert into VariantType (Name, OrganizationId) values ('Colour', @Organizationid)
    insert into VariantType (Name, OrganizationId) values ('Weight', @Organizationid)
end
go