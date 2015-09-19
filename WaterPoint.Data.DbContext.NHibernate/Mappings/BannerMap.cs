using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Data.DbContext.NHibernate.Mappings
{
    public class BannerMap : ClassMap<Banner>
    {
        public BannerMap()
        {
            SchemaAction.None();
            Id(t => t.Id);
            Map(t => t.IsActive);
            Map(t => t.Name);
            Map(t => t.Url);
            Map(t => t.Description);
            Map(t => t.UtcCreated);
            Map(t => t.UtcUpdated);

            References(t => t.Shop).Column("ShopId");
            References(t => t.BannerType).Column("BannerTypeId");

        }
    }
}
