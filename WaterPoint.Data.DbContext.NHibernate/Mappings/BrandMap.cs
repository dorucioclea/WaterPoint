using FluentNHibernate.Mapping;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Data.DbContext.NHibernate.Mappings
{
    public class BrandMap : ClassMap<Brand>
    {
        public BrandMap()
        {
            SchemaAction.None();
            Id(t => t.Id).GeneratedBy.Identity();
            Map(t => t.Name);
            Map(t => t.IsActive);
            Map(t => t.Description);
            Map(t => t.UtcCreated);
            Map(t => t.UtcUpdated);

            References(t => t.Shop).Column("ShopId");

            HasMany(t => t.Products).KeyColumn("Id");

            //HasManyToMany(t => t.Categories)
            //    .Table("ProductCategory")
            //    .ParentKeyColumn("ProductId")
            //    .ChildKeyColumn("CateogryId")
            //    .Cascade
            //    .Delete();
        }
    }
}
