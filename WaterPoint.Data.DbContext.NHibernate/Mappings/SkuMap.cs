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
            Id(t => t.Id).GeneratedBy.Identity();
            Map(t => t.Code);
            Map(t => t.Quantity);
            Map(t => t.UtcCreated);
            Map(t => t.UtcUpdated);

            References(t => t.Product)
                .ForeignKey("SkuId");

            HasManyToMany(t => t.Variants)
                .Table("SkuVariant")
                .ParentKeyColumn("SkuId")
                .ChildKeyColumn("VariantId")
                .Cascade.Delete()
                .Not
                .LazyLoad();
        }
    }
}
