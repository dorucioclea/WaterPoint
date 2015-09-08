using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Data.DbContext.NHibernate.Mappings
{
    public class BannerTypeMap : ClassMap<BannerType>
    {
        public BannerTypeMap()
        {
            Id(t => t.Id);
            References(t=>t.Shop).ForeignKey("ShopId");
            Map(t=>t.Name);
            HasMany(t => t.Banners).KeyColumn("Id");
        }
    }
}
