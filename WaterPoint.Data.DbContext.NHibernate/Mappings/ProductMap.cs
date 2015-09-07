using FluentNHibernate.Mapping;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Data.DbContext.NHibernate.Mappings
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            SchemaAction.None();
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name);
            Map(x => x.IsDeleted);
            Map(x => x.IsActive);
            Map(x => x.Description);
            Map(x => x.UtcCreated);
            Map(x => x.UtcUpdated);

            References(x => x.Shop).Column("ShopId");

            //HasMany(x => x.Skus).KeyColumn("ProductId").Inverse();

            //HasManyToMany(x => x.Categories)
            //    .Table("ProductCategory")
            //    .ParentKeyColumn("ProductId")
            //    .ChildKeyColumn("CateogryId")
            //    .Cascade
            //    .Delete();

            HasManyToMany(x => x.Flags) 
                .Table("ProductFlag")
                .ParentKeyColumn("ProductId")
                .ChildKeyColumn("FlagId")
                .LazyLoad()
                .Cascade
                .Delete();
        }
    }
}
