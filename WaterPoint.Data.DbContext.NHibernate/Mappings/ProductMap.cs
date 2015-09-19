using FluentNHibernate.Mapping;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Data.DbContext.NHibernate.Mappings
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Id(t => t.Id).GeneratedBy.Identity();
            Map(t => t.Name);
            Map(t => t.IsActive);
            Map(t => t.Description);
            Map(t => t.UtcCreated);
            Map(t => t.UtcUpdated);

            References(t => t.Shop).Column("ShopId");
            References(t => t.Brand).Column("BrandId");

            //HasManyToMany(t => t.Categories)
            //    .Table("ProductCategory")
            //    .ParentKeyColumn("ProductId")
            //    .ChildKeyColumn("CateogryId")
            //    .Cascade
            //    .Delete();

            HasManyToMany(t => t.Flags) 
                .Table("ProductFlag")
                .ParentKeyColumn("ProductId")
                .ChildKeyColumn("FlagId")
                .LazyLoad()
                .Cascade
                .Delete();
        }
    }
}
