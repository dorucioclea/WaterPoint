using System;
using System.Threading.Tasks;

namespace WaterPoint.Core.Domain
{
    public interface IApiClient
    {
        IApiContext Context { get; }
        Task<T> Get<T>() where T : class;
        Task<T> Post<T>() where T : class;
        Task<T> Delete<T>() where T : class;
        Task<T> Put<T>() where T : class;
        void Dispose();
    }
}
