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
    insert into dbo.Flag (Name) values ('Featured')
    insert into dbo.Flag (Name) values ('Sale')
    insert into dbo.Flag (Name) values ('Special')
end