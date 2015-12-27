MERGE INTO dbo.OrganizationUserType AS T
USING
(
	SELECT 1 AS Id, N'管理员' AS [Description]
	UNION ALL
	SELECT 2 AS Id, N'员工' AS [Description]
	UNION ALL
	SELECT 3 AS Id, N'客户' AS [Description]
	UNION ALL
	SELECT 4 AS Id, N'联系人' AS [Description]
) AS S

ON
	T.Id = S.Id

WHEN MATCHED THEN
	UPDATE SET [Description] = S.[Description]

WHEN NOT MATCHED BY TARGET THEN
	INSERT (Id, [Description])
    VALUES (S.Id, S.[Description])

WHEN NOT MATCHED BY SOURCE THEN
	DELETE;
GO
