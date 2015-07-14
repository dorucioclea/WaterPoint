using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPointSms.Data.Bll;
using WaterPointSms.Data.Contract;

namespace WaterPointSms.Data.Service
{
    public interface ILoginSafeService
    {
        Task<IEnumerable<LoginSafeContract>> ListLoginSafeByUser(int userId);
    }

    public class LoginSafeService : ILoginSafeService
    {
        private readonly ILoginSafeBll _loginSafeBll;

        public LoginSafeService(ILoginSafeBll loginSafeBll)
        {
            _loginSafeBll = loginSafeBll;
        }

        public async Task<IEnumerable<LoginSafeContract>> ListLoginSafeByUser(int userId)
        {
            var entities = await _loginSafeBll.ListByUserAsync(userId);

            var result = entities.Select(i =>
                new LoginSafeContract
                {
                    Url = i.Url,
                    Password = i.Password,
                    Name = i.Name,
                    LoginName = i.LoginName
                });

            return result;
        }
    }
}
