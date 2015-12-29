MERGE INTO dbo.Privilege AS T
USING
(
    SELECT 1 AS Id, N'添加客户' AS [Name], 0 AS [IsDeleted], N'AddCus' AS [Code]
    UNION ALL
    SELECT 2 AS Id, N'删除客户' AS [Name], 0 AS [IsDeleted], N'DelCus' AS [Code]
    UNION ALL
    SELECT 3 AS Id, N'修改客户' AS [Name], 0 AS [IsDeleted], N'EditCus' AS [Code]
    UNION ALL
    SELECT 4 AS Id, N'查看客户' AS [Name], 0 AS [IsDeleted], N'ViewCus' AS [Code]
    UNION ALL
    SELECT 5 AS Id, N'添加工作' AS [Name], 0 AS [IsDeleted], N'AddJob' AS [Code]
    UNION ALL
    SELECT 6 AS Id, N'删除工作' AS [Name], 0 AS [IsDeleted], N'DelJob' AS [Code]
    UNION ALL
    SELECT 7 AS Id, N'修改工作' AS [Name], 0 AS [IsDeleted], N'EditJob' AS [Code]
    UNION ALL
    SELECT 8 AS Id, N'查看工作' AS [Name], 0 AS [IsDeleted], N'ViewJob' AS [Code]
    UNION ALL
    SELECT 9 AS Id, N'添加费用' AS [Name], 0 AS [IsDeleted], N'AddCost' AS [Code]
    UNION ALL
    SELECT 10 AS Id, N'删除费用' AS [Name], 0 AS [IsDeleted], N'DelCost' AS [Code]
    UNION ALL
    SELECT 11 AS Id, N'修改费用' AS [Name], 0 AS [IsDeleted], N'EditCost' AS [Code]
    UNION ALL
    SELECT 12 AS Id, N'查看费用' AS [Name], 0 AS [IsDeleted], N'ViewCost' AS [Code]
    UNION ALL
    SELECT 13 AS Id, N'添加任务' AS [Name], 0 AS [IsDeleted], N'AddTask' AS [Code]
    UNION ALL
    SELECT 14 AS Id, N'删除任务' AS [Name], 0 AS [IsDeleted], N'DelTask' AS [Code]
    UNION ALL
    SELECT 15 AS Id, N'修改任务' AS [Name], 0 AS [IsDeleted], N'EditTask' AS [Code]
    UNION ALL
    SELECT 16 AS Id, N'查看任务' AS [Name], 0 AS [IsDeleted], N'ViewTask' AS [Code]
    UNION ALL
    SELECT 17 AS Id, N'添加工作时间' AS [Name], 0 AS [IsDeleted], N'AddJobTime' AS [Code]
    UNION ALL
    SELECT 18 AS Id, N'删除工作时间' AS [Name], 0 AS [IsDeleted], N'DelJobTime' AS [Code]
    UNION ALL
    SELECT 19 AS Id, N'修改工作时间' AS [Name], 0 AS [IsDeleted], N'EditJobTime' AS [Code]
    UNION ALL
    SELECT 20 AS Id, N'查看工作时间' AS [Name], 0 AS [IsDeleted], N'ViewJobTime' AS [Code]
) AS S

ON
	T.Id = S.Id

WHEN MATCHED THEN
	UPDATE SET [Name] = S.[Name], [IsDeleted] = S.[IsDeleted], [Code] = S.[Code]

WHEN NOT MATCHED BY TARGET THEN
	INSERT (Id, [Name], [IsDeleted], [Code])
    VALUES (S.Id, S.[Name], S.[IsDeleted], S.[Code])

WHEN NOT MATCHED BY SOURCE THEN
	UPDATE SET IsDeleted = 1;
GO
