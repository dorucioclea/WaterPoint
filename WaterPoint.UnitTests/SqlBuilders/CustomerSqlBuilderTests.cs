using System;
using WaterPoint.Api.Common;
using WaterPoint.Core.Bll;
using WaterPoint.Core.Domain.QueryParameters.Customers;
using WaterPoint.Data.Entity.DataEntities;
using Xunit;

namespace WaterPoint.UnitTests.SqlBuilders
{
    public class CustomerSqlBuilderTests
    {
        [Fact]
        public void Can_Generate_SelectSql_ForCustomer()
        {
            const string expectedSql = @"
                SELECT
                    c.[Id] ,
                    c.[OrganizationId] ,
                    c.[CustomerTypeId] ,
                    c.[IsProspect] ,
                    c.[Code] ,
                    c.[Phone] ,
                    c.[Email] ,
                    c.[FirstName] ,
                    c.[LastName] ,
                    c.[OtherName] ,
                    c.[MobilePhone] ,
                    c.[Version] ,
                    c.[Dob] ,
                    c.[Uid] ,
                    c.[UtcCreated] ,
                    c.[UtcUpdated]
                    ,[TotalCount]
                FROM
                    [dbo].[Customer] c
                    CROSS APPLY(
                        SELECT COUNT(*) TotalCount
                        FROM
                            [dbo].[Customer] c
                        WHERE
                            (c.[OrganizationId] = 1000)
AND (CONTAINS((c.[Code],c.[Email]), @searchterm) OR CONTAINS((c.[SearchName]), @searchterm))
                    )[Count]
                WHERE
                    (c.[OrganizationId] = 1000)
AND (CONTAINS((c.[Code],c.[Email]), @searchterm) OR CONTAINS((c.[SearchName]), @searchterm))
                ORDER BY 9 DESC
                OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY  ";

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

            var searchTerm = SearchTermHelper.ConvertToSearchTerm("test");

            builder.AddTemplate(sqlTemplate);
            builder.AddColumns<Customer>();
            builder.AddConditions<Customer>(i => i.OrganizationId == orgId);
            builder.AddOrderBy<Customer>("lastName", true);
            builder.AddContains<Customer>(searchTerm);

            var sql = builder.GetSql();

            Assert.Equal(TestUtility.NeutralizeString(sql), TestUtility.NeutralizeString(expectedSql));
        }

        [Fact]
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

            var customer = new UpdateCustomer
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
                UtcUpdated = DateTime.UtcNow,
                //Version = "version1"
            };

            var obj = new UpdateSqlBuilder<Customer>();

            obj.Analyze(customer);
            obj.AddValueParameters(customer);

            var orgId = 1000;

            obj.AddConditions<Customer>(i => i.OrganizationId == orgId && i.Id == customer.Id);

            var sql = obj.GetSql();

            Assert.Equal(TestUtility.NeutralizeString(sql), TestUtility.NeutralizeString(expectedSql));
        }
    }
}
