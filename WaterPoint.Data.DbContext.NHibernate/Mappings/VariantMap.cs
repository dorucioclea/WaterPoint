using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Data.DbContext.NHibernate.Mappings
{
    public class VariantMap : ClassMap<Variant>
    {
        public VariantMap()
        {
            Id(x => x.Id);
            Map(x => x.Value);
            Map(x => x.Order);

            HasManyToMany(x => x.Skus)
                .Table("SkuVariant")
                .ParentKeyColumn("VariantId")
                .ChildKeyColumn("SkuId")
                .Cascade.Delete();
        }
    }
}
