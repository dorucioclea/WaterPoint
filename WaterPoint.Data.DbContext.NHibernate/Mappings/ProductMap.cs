using FluentNHibernate.Mapping;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Data.DbContext.NHibernate.Mappings
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name);
            Map(x => x.Description);
            Map(x => x.CreatedOn);
            Map(x => x.UpdatedOn);
            HasMany(x => x.Skus).KeyColumn("ProductId");
            HasManyToMany(x => x.Categories)
                .Table("ProductCategory")
                .ParentKeyColumn("Id")
                .ChildKeyColumn("CateogryId")
                .Cascade
                .Delete();

        }
    }
}
