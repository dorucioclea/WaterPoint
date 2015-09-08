using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Core.Domain.SpecificationRequests.Banners
{
    public class ListBannersByBannerTypeRequest : ISpecificationRequest
    {
        public int ShopId { get; set; }
        public int BannerTypeId { get; set; }
    }
}
