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
using WaterPoint.Core.Domain.Requests;
using WaterPoint.Core.Domain.Requests.Products;
using WaterPoint.Core.Domain.Services;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Services.Products
{
    public class ListProductByFlagRequestService : IService<ListProductsByFlagRequest, IEnumerable<ProductContract>>
    {
        private readonly IProductRepository _productRepository;

        public ListProductByFlagRequestService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<ProductContract> Run(ListProductsByFlagRequest ti)
        {
            var result = _productRepository.ListProductsByFlag(ti.FlagId);

            return CoreMapperHelper.MapTo<IEnumerable<ProductContract>>(result);
        }
    }
}
