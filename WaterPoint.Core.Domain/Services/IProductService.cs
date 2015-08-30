using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Core.Domain.Services
{
    public interface IProductService
    {
        TO Run<TI, TO>(TI query);
    }
}
