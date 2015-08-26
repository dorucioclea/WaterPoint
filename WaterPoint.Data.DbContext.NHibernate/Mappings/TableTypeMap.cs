using FluentNHibernate.Mapping;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Data.DbContext.NHibernate.Mappings
{
    public class TableTypeMap : ClassMap<TableType>
    {
        public TableTypeMap()
        {
            Id(x => x.Id);
            Map(x => x.BranchId);
            Map(x => x.Name);
        }
    }
}
