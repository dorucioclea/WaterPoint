using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Data.DbContext.NHibernate.Mappings
{
    public class FlagMap : ClassMap<Flag>
    {
        public FlagMap()
        {
            SchemaAction.None();
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name);
            HasManyToMany(x => x.Products)
                .Table("ProductFlag")
                .ParentKeyColumn("FlagId")
                .ChildKeyColumn("ProductId");
        }
    }
}
