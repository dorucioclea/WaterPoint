using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaterPoint.Core.Domain.RequestDtos;

namespace WaterPoint.Core.Domain
{
    public interface IRequest
    {
    }

    public interface IRequestProcessor<in TInput, out TOutput>
        where TInput : IRequest
    {
        TOutput Process(TInput input);
    }
}
