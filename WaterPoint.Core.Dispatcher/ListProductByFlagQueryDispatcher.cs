using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Cqrs.Queries;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Repositories;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Dispatcher
{
    public class ListProductByFlagQueryDispatcher :
        IQueryDispatcher<ListProductsByFlagQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;

        public ListProductByFlagQueryDispatcher(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> Dispatch(ListProductsByFlagQuery query)
        {
            return _productRepository.ListProductsByFlag(query.FlagId);
        }
    }
}
