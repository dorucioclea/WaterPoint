using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.ContractMapper;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Banners;
using WaterPoint.Core.Domain.Contracts.Products;
using WaterPoint.Core.Domain.SpecificationRequests;
using WaterPoint.Core.Domain.SpecificationRequests.Banners;
using WaterPoint.Core.Domain.SpecificationRequests.Products;
using WaterPoint.Core.Domain.Specifications;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor
{
    public class ListProductsByFlagProcessor : IRequestProcessor<ListProductsByFlagRequest, IEnumerable<BasicProduct>>
    {
        private readonly ISpecification<ListProductsByFlagRequest, IEnumerable<Product>> _listProductsByFlagSpecification;
        
        public ListProductsByFlagProcessor(
            ISpecification<ListProductsByFlagRequest, IEnumerable<Product>> listProductsByFlagSpecification)
        {
            _listProductsByFlagSpecification = listProductsByFlagSpecification;
        }

        public IEnumerable<BasicProduct> Process(ListProductsByFlagRequest request)
        {
            var products = _listProductsByFlagSpecification.Run(request);

            var result = CoreMapperHelper.MapTo<IEnumerable<BasicProduct>>(products);

            return result;
        }
    }
}
