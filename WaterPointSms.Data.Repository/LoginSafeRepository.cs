using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.DbContext;
using WaterPointSms.Data.Entity;
using WaterPointSms.Data.Repository;

namespace WaterPoint.Data.Repository
{
    public interface ILoginSafeRepository
    {
        Task<IEnumerable<LoginSafe>> ListByUserIdAsync(int userId);
    }

    public class LoginSafeRepository : RepositoryBase<LoginSafe>, ILoginSafeRepository
    {
        public LoginSafeRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<IEnumerable<LoginSafe>> ListByUserIdAsync(int userId)
        {
            var result = await DbContext.QueryAsync<LoginSafe>(
                @"
                SELECT
                    [Id]
                    ,[UserId]
                    ,[Name]
                    ,[Url]
                    ,[Description]
                    ,[LoginName]
                    ,[Password]
                    ,[GroupId]
                    ,[CreatedOn]
                    ,[UpdatedOn]
                FROM [dbo].[LoginSafe]
                WHERE UserId = @userId
                ",
                new
                { 
                    userId
                });

            return result;
        }
    }
}
