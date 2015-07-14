using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.Repository;
using WaterPointSms.Data.Entity;

namespace WaterPointSms.Data.Bll
{
    public interface ILoginSafeBll
    {
        Task<IEnumerable<LoginSafe>> ListByUserAsync(int userId);
    }

    public class LoginSafeBll : ILoginSafeBll
    {
        private readonly ILoginSafeRepository _loginSafeRepo;

        public LoginSafeBll(ILoginSafeRepository loginSafeRepo)
        {
            _loginSafeRepo = loginSafeRepo;
        }

        public async Task<IEnumerable<LoginSafe>> ListByUserAsync(int userId)
        {
            return await _loginSafeRepo.ListByUserIdAsync(userId);
        }
    }
}
