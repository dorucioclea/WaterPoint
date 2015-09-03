using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain.Requests;

namespace WaterPoint.Core.Domain.Services
{
    public interface IService<in TI, out TOut>
        where TI : IServiceRequest
    {
        TOut Run(TI ti);

    }
}
