using FluentNHibernate.Mapping;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Data.DbContext.NHibernate.Mappings
{
    public class TableMap : ClassMap<Table>
    {
        public TableMap()
        {
            Id(x => x.Id);
            Map(x => x.BranchId);
            Map(x => x.TableTypeId);
            Map(x => x.Code);
            Map(x => x.NumberOfSeats);
            Map(x => x.MaxNumberOfSeats);
        }
    }
}
