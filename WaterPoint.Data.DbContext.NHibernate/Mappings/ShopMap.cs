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
            SchemaAction.None();
            Id(x => x.Id).GeneratedBy.Identity();

            Map(x => x.CountryId);
            Map(x => x.Name);
            Map(x => x.DisplayName);
            Map(x => x.IsActive);
            Map(x => x.UtcCreated);
            Map(x => x.UtcUpdated);

            HasMany(x => x.Products).KeyColumn("Id");
        }
    }
}
