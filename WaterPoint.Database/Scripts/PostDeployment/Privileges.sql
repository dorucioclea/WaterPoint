MERGE INTO dbo.Privilege AS T
USING
(
    SELECT 1 AS Id, N'添加客户' AS [Name], 0 AS [IsDeleted], N'ADDCUS' AS [Code]
    UNION ALL
    SELECT 2 AS Id, N'删除客户' AS [Name], 0 AS [IsDeleted], N'DELCUS' AS [Code]
    UNION ALL
    SELECT 3 AS Id, N'修改客户' AS [Name], 0 AS [IsDeleted], N'EDITCUS' AS [Code]
    UNION ALL
    SELECT 4 AS Id, N'查看客户' AS [Name], 0 AS [IsDeleted], N'VIEWCUS' AS [Code]
    UNION ALL
    SELECT 5 AS Id, N'添加工作' AS [Name], 0 AS [IsDeleted], N'ADDJOB' AS [Code]
    UNION ALL
    SELECT 6 AS Id, N'删除工作' AS [Name], 0 AS [IsDeleted], N'DELJOB' AS [Code]
    UNION ALL
    SELECT 7 AS Id, N'修改工作' AS [Name], 0 AS [IsDeleted], N'EDITJOB' AS [Code]
    UNION ALL
    SELECT 8 AS Id, N'查看工作' AS [Name], 0 AS [IsDeleted], N'VIEWJOB' AS [Code]
    UNION ALL
    SELECT 9 AS Id, N'添加费用' AS [Name], 0 AS [IsDeleted], N'ADDCOST' AS [Code]
    UNION ALL
    SELECT 10 AS Id, N'删除费用' AS [Name], 0 AS [IsDeleted], N'DELCOST' AS [Code]
    UNION ALL
    SELECT 11 AS Id, N'修改费用' AS [Name], 0 AS [IsDeleted], N'EDITCOST' AS [Code]
    UNION ALL
    SELECT 12 AS Id, N'查看费用' AS [Name], 0 AS [IsDeleted], N'VIEWCOST' AS [Code]
    UNION ALL
    SELECT 13 AS Id, N'添加任务' AS [Name], 0 AS [IsDeleted], N'ADDTASK' AS [Code]
    UNION ALL
    SELECT 14 AS Id, N'删除任务' AS [Name], 0 AS [IsDeleted], N'DELTASK' AS [Code]
    UNION ALL
    SELECT 15 AS Id, N'修改任务' AS [Name], 0 AS [IsDeleted], N'EDITTASK' AS [Code]
    UNION ALL
    SELECT 16 AS Id, N'查看任务' AS [Name], 0 AS [IsDeleted], N'VIEWTASK' AS [Code]
    UNION ALL
    SELECT 17 AS Id, N'添加工作时间' AS [Name], 0 AS [IsDeleted], N'ADDJOBTIME' AS [Code]
    UNION ALL
    SELECT 18 AS Id, N'删除工作时间' AS [Name], 0 AS [IsDeleted], N'DELJOBTIME' AS [Code]
    UNION ALL
    SELECT 19 AS Id, N'修改工作时间' AS [Name], 0 AS [IsDeleted], N'EDITJOBTIME' AS [Code]
    UNION ALL
    SELECT 20 AS Id, N'查看工作时间' AS [Name], 0 AS [IsDeleted], N'VIEWJOBTIME' AS [Code]
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
