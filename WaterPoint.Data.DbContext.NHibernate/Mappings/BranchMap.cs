using FluentNHibernate.Mapping;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Data.DbContext.NHibernate.Mappings
{
    public class BranchMap : ClassMap<Branch>
    {
        public BranchMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name);
            Map(x => x.Code);
            Map(x => x.CreatedOn);
            Map(x => x.UpdatedOn);
            References(x => x.Restaurant, "RestaurantId");
            HasMany(x => x.TableTypes).KeyColumn("BranchId");
        }
    }
}
