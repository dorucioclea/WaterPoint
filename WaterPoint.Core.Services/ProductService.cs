using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WaterPoint.Core.ContractMapper;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Repositories;
using WaterPoint.Core.Domain.Services;

namespace WaterPoint.Core.Services
{

    public class ProductService : IProductService
    {
        public TO Run<TI, TO>(TI query)
        {
            throw  new NotImplementedException();
        }
    }
}
