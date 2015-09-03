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
            Map(x => x.Description);
            Map(x => x.UtcCreatedOn);
            Map(x => x.UtcUpdatedOn);
            //HasMany(x => x.Skus).KeyColumn("ProductId");
            //HasManyToMany(x => x.Categories)
            //    .Table("ProductCategory");
            //    .ParentKeyColumn("Id")
            //    .ChildKeyColumn("CateogryId")
            //    .Cascade
            //    .Delete();
            HasManyToMany(x => x.Flags)
                .Table("ProductFlag")
                .ParentKeyColumn("ProductId")
                .ChildKeyColumn("FlagId");
        }
    }
}
