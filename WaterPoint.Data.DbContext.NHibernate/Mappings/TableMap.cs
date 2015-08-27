using FluentNHibernate.Mapping;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Data.DbContext.NHibernate.Mappings
{
    public class TableMap : ClassMap<Table>
    {
        public TableMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Code);
            Map(x => x.NumberOfSeats);
            Map(x => x.MaxNumberOfSeats).Nullable();
            References(x => x.Branch);
            References(x => x.TableType);
        }
    }
}
