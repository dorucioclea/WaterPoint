using WaterPoint.Data.Entity.Attributes;

namespace WaterPoint.Data.Entity.DataEntities
{
    [Table("dbo", "PriorityType", "pri")]
    public class PriorityType : IDataEntity
    {
        [Primary]
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
