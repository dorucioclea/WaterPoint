using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Core.Domain
{
    public interface IApiContext
    {
        Uri BaseUri { get; }
        Uri EndpointUri { get; }
        string Payload { get; }
        IApiContext Append(string urlNode);
        IApiContext SetPayload(object payload, Func<object, string> serializer);
    }
}
