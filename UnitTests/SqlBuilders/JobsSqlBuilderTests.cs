﻿using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WaterPoint.Core.Bll;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.Jobs;

namespace UnitTests.SqlBuilders
{
    [TestClass]
    public class JobsSqlBuilderTests
    {
        [TestMethod]
        public void Can_Generate_CreateSql_ForJob()
        {
            //const string expectedSql = @"
            //    INSERT INTO [dbo].[Job]
            //    (
            //        [dbo].[Job].[OrganizationId],
            //        [dbo].[Job].[JobStatusId],
            //        [dbo].[Job].[Code],
            //        [dbo].[Job].[ShortDescription],
            //        [dbo].[Job].[LongDescription],
            //        [dbo].[Job].[CustomerId],
            //        [dbo].[Job].[StartDate],
            //        [dbo].[Job].[EndDate],
            //        [dbo].[Job].[DueDate]
            //    VALUES
            //    (
            //        @organizationid,@jobstatusid,@code,@shortdescription,@longdescription,@customerid,@startdate,@enddate,@duedate
            //    )
            //    SELECT SCOPE_IDENTITY()";

            //var job = new Job
            //{
            //    Id = 123,
            //    OrganizationId = 1000,
            //    Code = "testcode",
            //    CustomerId = 1000,
            //    DueDate = DateTime.UtcNow,
            //    EndDate = DateTime.UtcNow,
            //    StartDate = DateTime.UtcNow,
            //    JobStatusId = 3,
            //    LongDescription = "long desc",
            //    ShortDescription = "short desc",
            //    Uid = Guid.NewGuid(),
            //    UtcCreated = DateTime.UtcNow,
            //    UtcUpdated = DateTime.UtcNow
            //};

            //var obj = new CreateSqlBuilder<Job>();

            //obj.Analyze();
            //obj.AddValueParameters(job);

            //var sql = obj.GetSql();

            //Assert.AreEqual(TestUtility.NeutralizeString(sql), TestUtility.NeutralizeString(expectedSql));
        }

        [TestMethod]
        public void Can_Generate_SelectSql_With_Foreign_Tables()
        {
            const string expectedSql = @"
                SELECT
                    j.[Id], 
					j.[OrganizationId], 
					j.[JobStatusId], 
					j.[JobCategoryId], 
					j.[Code], 
					j.[CustomerId], 
					j.[StartDate], 
					j.[EndDate], 
					j.[DueDate], 
					j.[Version], 
					j.[UtcCreated], 
					j.[UtcUpdated], 
					j.[Uid], 
					js.[Name] AS [JobStatus], 
					c.[CustomerTypeId] AS [CustomerTypeId], 
					c.[LastName] AS [LastName], 
					c.[FirstName] AS [FirstName], 
					c.[OtherName] AS [OtherName]
                    ,[TotalCount]
                FROM
                    [dbo].[Job] j					
                    JOIN [dbo].[JobStatus] js ON j.[JobStatusId] = js.[Id]
					JOIN [dbo].[Customer] c ON j.[CustomerId] = c.[Id]
                    CROSS APPLY(
                        SELECT COUNT(*) TotalCount
                        FROM
                            [dbo].[Job] j
                            JOIN [dbo].[JobStatus] js ON j.[JobStatusId] = js.[Id]
							JOIN [dbo].[Customer] c ON j.[CustomerId] = c.[Id]
                        WHERE
                            (j.[OrganizationId] = @orgid)
                    )[Count]
                WHERE
                    (j.[OrganizationId] = @orgid)
                ORDER BY 17  
                OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY  ";

            var sqlTemplate = $@"
                SELECT
                    {SqlPatterns.Columns}
                    ,[TotalCount]
                FROM
                    {SqlPatterns.FromTable}
                    {SqlPatterns.Join}
                    CROSS APPLY(
                        SELECT COUNT(*) TotalCount
                        FROM
                            {SqlPatterns.FromTable}
                            {SqlPatterns.Join}
                        WHERE
                            {SqlPatterns.Where}
                    )[Count]
                WHERE
                    {SqlPatterns.Where}
                ORDER BY {SqlPatterns.OrderBy}
                OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY  ";

            var builder = new SelectSqlBuilder();

            var orgId = 1000;

            builder.AddTemplate(sqlTemplate);
            builder.AddColumns<JobWithCustomerAndStatusPoco>();
            builder.AddJoin<JobWithCustomerAndStatusPoco>();
            builder.AddConditions<JobWithCustomerAndStatusPoco>(i => i.OrganizationId == orgId);
            builder.AddOrderBy<JobWithCustomerAndStatusPoco>("FirstName", false);
            builder.AddContains<JobWithCustomerAndStatusPoco>("test");

            var sql = builder.GetSql();

            Assert.AreEqual(TestUtility.NeutralizeString(sql), TestUtility.NeutralizeString(expectedSql));

        }
    }
}
