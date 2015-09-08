//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using FluentNHibernate.Mapping;
//using WaterPoint.Data.Entity.DataEntities;

//namespace WaterPoint.Data.DbContext.NHibernate.Mappings
//{
//    public class CategoryMap : ClassMap<Category>
//    {
//        public CategoryMap()
//        {
//            Id(t => t.Id).GeneratedBy.Identity();
//            Map(t => t.Name);
//            Map(t => t.CreatedOn);
//            Map(t => t.UpdatedOn);
//            HasManyToMany(t => t.Products)
//                .Table("ProductCategory")
//                .ParentKeyColumn("CategoryId")
//                .ChildKeyColumn("ProductId")
//                .Cascade
//                .Delete();
//        }
//    }
//}
