using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.ContractMapper;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Products;
using WaterPoint.Core.Domain.SpecificationRequests;
using WaterPoint.Core.Domain.SpecificationRequests.Products;
using WaterPoint.Core.Domain.Specifications;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Services
{
    public class ListProductsByFlagRequestProcessor : IRequestProcessor<ListProductsByFlag, IEnumerable<ProductMinimumMetaInfoContract>>
    {
        private readonly ISpecification<ListProductsByFlag, IEnumerable<Product>> _listProductsByFlagSpecification;
        
        public ListProductsByFlagRequestProcessor(
            ISpecification<ListProductsByFlag, IEnumerable<Product>> listProductsByFlagSpecification)
        {
            _listProductsByFlagSpecification = listProductsByFlagSpecification;
        }

        public IEnumerable<ProductMinimumMetaInfoContract> Process(ListProductsByFlag request)
        {
            var products = _listProductsByFlagSpecification.Run(request);

            var result = CoreMapperHelper.MapTo<IEnumerable<ProductMinimumMetaInfoContract>>(products);

            return result;
        }
    }
}
