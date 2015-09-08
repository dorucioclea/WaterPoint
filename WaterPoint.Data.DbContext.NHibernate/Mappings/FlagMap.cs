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
            Id(t => t.Id).GeneratedBy.Identity();
            Map(t => t.Name);
            HasManyToMany(t => t.Products)
                .Table("ProductFlag")
                .ParentKeyColumn("FlagId")
                .ChildKeyColumn("ProductId");
        }
    }
}
