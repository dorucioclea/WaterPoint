using FluentNHibernate.Mapping;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Data.DbContext.NHibernate.Mappings
{
    public class TableTypeMap : ClassMap<TableType>
    {
        public TableTypeMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name);
            References(x => x.Branch, "BranchId");
            HasMany(x => x.Tables).KeyColumn("TableTypeId");
        }
    }
}
