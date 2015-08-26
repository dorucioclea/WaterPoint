
MERGE INTO dbo.Country AS T
USING 
(
	SELECT 1 AS Id, 'New Zealand' AS Name, 'NZ' AS Code
	UNION ALL
	SELECT 2 AS Id, 'Australia' AS Name, 'AU' AS Code
) AS S 

ON 
	T.Id = S.Id

WHEN MATCHED THEN 
	UPDATE SET Name = S.Name, Code = S.Code

WHEN NOT MATCHED BY TARGET THEN 
	INSERT (Id, Name, Code) 
    VALUES (S.Id, S.Name, S.Code)

WHEN NOT MATCHED BY SOURCE THEN
	DELETE;
GO