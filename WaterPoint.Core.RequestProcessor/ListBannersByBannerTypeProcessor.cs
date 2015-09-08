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
    public class ListBannersByBannerTypeProcessor : IRequestProcessor<ListBannersByBannerTypeRequest, IEnumerable<BasicBanner>>
    {
        private readonly ISpecification<ListBannersByBannerTypeRequest, IEnumerable<Banner>> _listBannersByBannerTypeSpecification;

        public ListBannersByBannerTypeProcessor(
            ISpecification<ListBannersByBannerTypeRequest, IEnumerable<Banner>> listBannersByBannerTypeSpecification)
        {
            _listBannersByBannerTypeSpecification = listBannersByBannerTypeSpecification;
        }

        public IEnumerable<BasicBanner> Process(ListBannersByBannerTypeRequest request)
        {
            var banners = _listBannersByBannerTypeSpecification.Run(request);

            var result = CoreMapperHelper.MapTo<IEnumerable<BasicBanner>>(banners);

            return result;
        }
    }
}
