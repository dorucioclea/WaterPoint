MERGE INTO dbo.JobTimesheetType AS i
USING
(
	SELECT 1 AS Id, N'草稿' AS [Description]
    UNION ALL
    SELECT 2 AS Id, N'记时器' AS [Description]
    UNION ALL
    SELECT 3 AS Id, N'时间表' AS [Description]
) AS s
ON 	i.Id = s.Id

WHEN MATCHED THEN UPDATE SET [Description] = S.[Description]

WHEN NOT MATCHED BY TARGET THEN
	INSERT (Id, [Description])
	VALUES (s.Id, S.[Description])

WHEN NOT MATCHED BY SOURCE THEN DELETE;
GO
