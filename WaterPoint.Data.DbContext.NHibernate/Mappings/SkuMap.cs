//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using FluentNHibernate.Mapping;
//using WaterPoint.Data.Entity.DataEntities;

//namespace WaterPoint.Data.DbContext.NHibernate.Mappings
//{
//    public class SkuMap : ClassMap<Sku>
//    {
//        public SkuMap()
//        {
//            Id(x => x.Id).GeneratedBy.Identity();
//            Map(x => x.Code);
//            Map(x => x.Quantity);
//            Map(x => x.CreatedOn);
//            Map(x => x.UpdatedOn);
//            References(x => x.Product)
//                .ForeignKey("SkuId");
//            //HasMany(x => x.SkuVariants)
//            //    .KeyColumn("SkuId");
//        }

//    }
//}
