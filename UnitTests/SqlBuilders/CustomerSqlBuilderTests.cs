using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using WaterPoint.Core.Bll;
using WaterPoint.Data.Entity.DataEntities;

namespace UnitTests.SqlBuilders
{
    [TestClass]
    public class CustomerSqlBuilderTests
    {
        [TestMethod]
        public void Can_Generate_SelectSql_ForCustomer()
        {
            const string expectedSql = @"";

            var sqlTemplate = $@"
                SELECT
                    {SqlPatterns.Columns}
                    ,[TotalCount]
                FROM
                    {SqlPatterns.FromTable}
                    CROSS APPLY(
                        SELECT COUNT(*) TotalCount
                        FROM
                            {SqlPatterns.FromTable}
                        WHERE
                            {SqlPatterns.Where}
                    )[Count]
                WHERE
                    {SqlPatterns.Where}
                ORDER BY {SqlPatterns.OrderBy}
                OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY  ";

            var builder = new SelectSqlBuilder();

            const int orgId = 1000;

            builder.AddTemplate(sqlTemplate);
            builder.AddPrimaryColumns<Customer>();
            builder.AddConditions<Customer>(i => i.OrganizationId == orgId);
            builder.AddOrderBy<Customer>("lastName", true);
            builder.AddContains<Customer>("test");

            var sql = builder.GetSql();

            Assert.AreEqual(TestUtility.NeutralizeString(sql), TestUtility.NeutralizeString(expectedSql));


        }

        [TestMethod]
        public void Can_Generate_UpdateSql_ForCustomer()
        {
            const string expectedSql = @"
                UPDATE [dbo].[Customer]
                SET [dbo].[Customer].[CustomerTypeId] = @customertypeid,
                    [dbo].[Customer].[Code] = @code,
                    [dbo].[Customer].[Phone] = @phone,
                    [dbo].[Customer].[Email] = @email,
                    [dbo].[Customer].[FirstName] = @firstname,
                    [dbo].[Customer].[LastName] = @lastname,
                    [dbo].[Customer].[OtherName] = @othername,
                    [dbo].[Customer].[MobilePhone] = @mobilephone,
                    [dbo].[Customer].[Dob] = @dob,
                    [dbo].[Customer].[UtcUpdated] = @utcupdated
                WHERE (([dbo].[Customer].[OrganizationId] = @orgid) AND ([dbo].[Customer].[Id] = @id))";

            var customer = new Customer
            {
                Id = 123,
                OrganizationId = 1000,
                Code = "testcode",
                CustomerTypeId = null,
                Dob = null,
                Email = "test@email.com",
                FirstName = "miao",
                LastName = "huang",
                MobilePhone = "123",
                OtherName = "cang",
                Phone = "321",
                Uid = Guid.NewGuid(),
                UtcCreated = DateTime.UtcNow,
                UtcUpdated = DateTime.UtcNow,
                //Version = "version1"
            };

            var obj = new UpdateSqlBuilder<Customer>();

            obj.Analyze();
            obj.AddValueParameters(customer);

            var orgId = 1000;

            obj.AddConditions<Customer>(i => i.OrganizationId == orgId && i.Id == customer.Id);

            var sql = obj.GetSql();

            Assert.AreEqual(TestUtility.NeutralizeString(sql), TestUtility.NeutralizeString(expectedSql));


        }
    }
}
