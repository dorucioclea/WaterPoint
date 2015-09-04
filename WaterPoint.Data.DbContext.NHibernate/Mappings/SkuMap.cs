using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Data.DbContext.NHibernate.Mappings
{
    public class SkuMap : ClassMap<Sku>
    {
        public SkuMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Code);
            Map(x => x.Quantity);
            Map(x => x.UtcCreatedOn);
            Map(x => x.UtcUpdatedOn);

            References(x => x.Product)
                .ForeignKey("SkuId");

            HasManyToMany(x => x.Variants)
                .Table("SkuVariant")
                .ParentKeyColumn("SkuId")
                .ChildKeyColumn("VariantId")
                .Cascade.Delete()
                .Not
                .LazyLoad();
        }
    }
}
