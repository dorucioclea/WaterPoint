using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Bll.QueryParameters.CostItems
{
    public class CreateCostItem : IQueryParameter
    {
        public int OrganizationId { get; set; }

        public int? SupplierId { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public string Code { get; set; }

        public decimal? UnitCost { get; set; }

        public decimal? UnitPrice { get; set; }

        public bool? IsBillable { get; set; }
    }
}
