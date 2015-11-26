using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WaterPoint.Core.Bll;
using WaterPoint.Data.Entity.DataEntities;

namespace UnitTests.SqlBuilders
{
    [TestClass]
    public class JobsSqlBuilderTests
    {
        [TestMethod]
        public void Can_Generate_CreateSql_ForJob()
        {
            const string expectedSql = @"
                INSERT INTO [dbo].[Job]
                (
                    [dbo].[Job].[OrganizationId],
                    [dbo].[Job].[JobStatusId],
                    [dbo].[Job].[Code],
                    [dbo].[Job].[ShortDescription],
                    [dbo].[Job].[LongDescription],
                    [dbo].[Job].[CustomerId],
                    [dbo].[Job].[StartDate],
                    [dbo].[Job].[EndDate],
                    [dbo].[Job].[DueDate]
                VALUES
                (
                    @organizationid,@jobstatusid,@code,@shortdescription,@longdescription,@customerid,@startdate,@enddate,@duedate
                )
                SELECT SCOPE_IDENTITY()";

            var job = new Job
            {
                Id = 123,
                OrganizationId = 1000,
                Code = "testcode",
                CustomerId = 1000,
                DueDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow,
                StartDate = DateTime.UtcNow,
                JobStatusId = 3,
                LongDescription = "long desc",
                ShortDescription = "short desc",
                Uid = Guid.NewGuid(),
                UtcCreated = DateTime.UtcNow,
                UtcUpdated = DateTime.UtcNow
            };

            var obj = new CreateSqlBuilder<Job>();

            obj.Analyze();
            obj.AddValueParameters(job);
            
            var sql = obj.GetSql();

            Assert.AreEqual(TestUtility.NeutralizeString(sql), TestUtility.NeutralizeString(expectedSql));
        }
    }
}
