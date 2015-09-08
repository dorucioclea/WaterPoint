using FluentNHibernate.Mapping;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Data.DbContext.NHibernate.Mappings
{
    public class BrandMap : ClassMap<Brand>
    {
        public BrandMap()
        {
            SchemaAction.None();
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name);
            Map(x => x.IsActive);
            Map(x => x.Description);
            Map(x => x.UtcCreated);
            Map(x => x.UtcUpdated);

            References(x => x.Shop).Column("ShopId");

            HasMany(x => x.Products).KeyColumn("Id");

            //HasManyToMany(x => x.Categories)
            //    .Table("ProductCategory")
            //    .ParentKeyColumn("ProductId")
            //    .ChildKeyColumn("CateogryId")
            //    .Cascade
            //    .Delete();
        }
    }
}
