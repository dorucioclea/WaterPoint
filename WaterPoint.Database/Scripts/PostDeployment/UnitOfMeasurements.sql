MERGE INTO dbo.UnitOfMeasurement AS i
USING
(
	SELECT 1 AS Id, N'个件' AS [Description]
    UNION ALL
    SELECT 2 AS Id, N'天' AS [Description]
    UNION ALL
    SELECT 3 AS Id, N'小时' AS [Description]
) AS s
ON 	i.Id = s.Id

WHEN MATCHED THEN UPDATE SET [Description] = s.[Description]

WHEN NOT MATCHED BY TARGET THEN
	INSERT (Id, [Description])
	VALUES (s.Id, s.[Description])

WHEN NOT MATCHED BY SOURCE THEN DELETE;
GO
