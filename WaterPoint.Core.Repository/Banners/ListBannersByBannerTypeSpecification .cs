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
using WaterPoint.Core.Domain.SpecificationRequests.Banners;
using WaterPoint.Core.Domain.SpecificationRequests.Products;
using WaterPoint.Core.Domain.Specifications;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Repository.Banners
{
    public class ListBannersByBannerTypeSpecification : ISpecification<ListBannersByBannerTypeRequest, IEnumerable<Banner>>
    {
        private readonly INHibernateRepository<Product> _repository;

        public ListBannersByBannerTypeSpecification(
            INHibernateRepository<Product> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Banner> Run(ListBannersByBannerTypeRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
