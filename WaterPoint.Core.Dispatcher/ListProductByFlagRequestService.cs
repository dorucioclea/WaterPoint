using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Repositories;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Dispatcher
{
    public class ListProductByFlagRequestService :
        IQueryDispatcher<ListProductsByFlagRequest, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;

        public ListProductByFlagRequestService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> Dispatch(ListProductsByFlagRequest request)
        {
            return _productRepository.ListProductsByFlag(request.FlagId);
        }
    }
}
