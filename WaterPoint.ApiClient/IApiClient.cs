using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace WaterPoint.ApiClient
{
    public interface IApiClient
    {
        Task<T> Get<T>() where T : class;
        Task<T> Post<T>(T payloadObject) where T : class;
        Task<T> Delete<T>() where T : class;
        Task<T> Put<T>(T payloadObject) where T : class;
        IApiClient SetUri(Uri uri);
        IApiClient AddHeader(HttpRequestHeader header, string value);
        IApiClient SetData(object data);
        void Dispose();
    }
}
