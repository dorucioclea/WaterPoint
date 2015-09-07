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
    public class ListProductByFlagSpecification : ISpecification<ListProductsByFlag, IEnumerable<Product>>
    {
        private readonly INHibernateRepository<Product> _repository;

        public ListProductByFlagSpecification(
            INHibernateRepository<Product> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Product> Run(ListProductsByFlag request)
        {
            var result = _repository.Session
                .QueryOver<Product>()
                .Where(p => p.IsActive && !p.IsDeleted && p.Shop.Id == request.ShopId)
                .JoinQueryOver<Flag>(p => p.Flags)
                .Where(f => f.Id == request.FlagId)
                .List();

            return result;
        }
    }
}
