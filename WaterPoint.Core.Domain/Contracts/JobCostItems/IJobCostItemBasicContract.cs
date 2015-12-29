namespace WaterPoint.Core.Domain.Contracts.JobCostItems
{
    public interface IJobCostItemBasicContract : IContract
    {
        int Id { get; set; }
        int JobId { get; set; }
        int? CostItemId { get; set; }
        string Code { get; set; }
        decimal UnitCost { get; set; }
        decimal UnitPrice { get; set; }
        int Quantity { get; set; }
        bool IsBillable { get; set; }
        bool IsActual { get; set; }
        bool IsDeleted { get; set; }
        string Version { get; set; }
        string Uid { get; set; }
    }
}
