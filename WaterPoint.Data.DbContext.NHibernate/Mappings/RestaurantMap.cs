using FluentNHibernate.Mapping;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Data.DbContext.NHibernate.Mappings
{
    public class RestaurantMap : ClassMap<Restaurant>
    {
        public RestaurantMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name);
            Map(x => x.PreferedName);
            Map(x => x.Phone);
            Map(x => x.Uid);
            HasMany(x => x.Branches);
        }
    }
}
