using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain.SpecificationRequests;

namespace WaterPoint.Core.Domain.Specifications
{
    public interface ISpecification<in TI, out TOut>
        where TI : ISpecificationRequest
    {
        TOut Run(TI ti);

    }
}
