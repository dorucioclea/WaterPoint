using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.ContractMapper;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Contracts.Products;
using WaterPoint.Core.Domain.Repositories;
using WaterPoint.Core.Domain.SpecificationRequests.Products;
using WaterPoint.Core.Domain.Specifications;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Repository.Products
{
    public class ListProductByFlagSpecification : ISpecification<ListProductsByFlagRequest, IEnumerable<Product>>
    {
        public ListProductByFlagSpecification()
        {
        }

        public IEnumerable<Product> Run(ListProductsByFlagRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
