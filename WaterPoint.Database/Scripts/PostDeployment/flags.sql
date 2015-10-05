--MERGE INTO dbo.Flag AS T
--USING 
--(
--	SELECT 10 AS Id, 'Featured' AS Name
--	UNION ALL
--	SELECT 11 AS Id, 'Sale' AS Name
--    UNION ALL
--	SELECT 12 AS Id, 'Special' AS Name
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
if(select count(*) from dbo.Flag) = 0 begin
    declare @Organizationid int = (SELECT Id from dbo.Organization where name = 'water point')
    insert into dbo.Flag (Name, OrganizationId) values ('Featured', @Organizationid)
    insert into dbo.Flag (Name, OrganizationId) values ('Sale', @Organizationid)
    insert into dbo.Flag (Name, OrganizationId) values ('Special', @Organizationid)
end
go