using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Data.DbContext.NHibernate.Mappings
{
    public class ShopMap : ClassMap<Shop>
    {
        public ShopMap()
        {
            Id(t => t.Id).GeneratedBy.Identity();

            Map(t => t.CountryId);
            Map(t => t.Name);
            Map(t => t.DisplayName);
            Map(t => t.IsActive);
            Map(t => t.UtcCreated);
            Map(t => t.UtcUpdated);

            HasMany(t => t.Products).KeyColumn("Id");
            HasMany(t => t.Banners).KeyColumn("Id");
            HasMany(t => t.BannerTypes).KeyColumn("Id");
        }
    }
}
