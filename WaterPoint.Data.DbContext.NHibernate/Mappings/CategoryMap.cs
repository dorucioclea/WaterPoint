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
//            Id(x => x.Id).GeneratedBy.Identity();
//            Map(x => x.Name);
//            Map(x => x.CreatedOn);
//            Map(x => x.UpdatedOn);
//            HasManyToMany(x => x.Products)
//                .Table("ProductCategory")
//                .ParentKeyColumn("Id")
//                .ChildKeyColumn("ProductId")
//                .Cascade
//                .Delete();
//        }
//    }
//}
