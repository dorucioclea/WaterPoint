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
    declare @shopid int = (select Id from dbo.shop where name = 'water point')
    insert into VariantType (Name, ShopId) values ('Size', @shopid)
    insert into VariantType (Name, ShopId) values ('Colour', @shopid)
    insert into VariantType (Name, ShopId) values ('Weight', @shopid)
end
go