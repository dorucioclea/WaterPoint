using System;
using System.Threading.Tasks;

namespace WaterPoint.Core.Domain
{
    public interface IApiClient
    {
        Task<T> Delete<T>(string action, object data) where T : class;
        Task<T> Get<T>(string action) where T : class;
        Task<T> Post<T>(string action, object data) where T : class;
        Task<T> Put<T>(string action, object data) where T : class;

        void Dispose();
    }
}
