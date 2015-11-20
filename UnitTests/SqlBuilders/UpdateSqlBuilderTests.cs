using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WaterPoint.Core.Bll;
using WaterPoint.Data.Entity.DataEntities;

namespace UnitTests.SqlBuilders
{
    [TestClass]
    public class UpdateSqlBuilderTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string expectedColumns = @"
                [dbo].[Customer].[CustomerTypeId] = @customertypeid,
                [dbo].[Customer].[Code] = @code,
                [dbo].[Customer].[Phone] = @phone,
                [dbo].[Customer].[Email] = @email,
                [dbo].[Customer].[FirstName] = @firstname,
                [dbo].[Customer].[LastName] = @lastname,
                [dbo].[Customer].[OtherName] = @othername,
                [dbo].[Customer].[MobilePhone] = @mobilephone,
                [dbo].[Customer].[UpdatedByStaffId] = @updatedbystaffid,
                [dbo].[Customer].[Version] = @version,
                [dbo].[Customer].[Dob] = @dob,
                [dbo].[Customer].[UtcUpdated] = @utcupdated";

            const string expectedWhere = @"(([dbo].[Customer].[OrganizationId] = 1000) AND ([dbo].[Customer].[Id] = 123))";

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
                UpdatedByStaffId = 1,
                UtcCreated = DateTime.UtcNow,
                UtcUpdated = DateTime.UtcNow,
                Version = "version1"
            };

            var obj = new UpdateSqlBuilder<Customer>();

            obj.Analyze();
            obj.AddValueParameters(customer);
            obj.AddConditions<Customer>(i => i.OrganizationId == 1000 && i.Id == 123);

            Assert.AreEqual(NeutralizeString(obj.Columns), NeutralizeString(expectedColumns));
            Assert.AreEqual(NeutralizeString(obj.Where), NeutralizeString(expectedWhere));
        }

        private static string NeutralizeString(string str)
        {
            return str.Replace("\r\n", string.Empty).ToLower().Replace(" ", string.Empty);
        }
    }
}
