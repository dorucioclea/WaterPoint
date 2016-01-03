namespace WaterPoint.Core.Domain.Contracts.QuoteTasks
{
    public class QuoteTaskBasicContract : IContract
    {
        public int Id { get; set; }
        public int QuoteId { get; set; }
        public int TaskDefinitionId { get; set; }
        public int? DisplayOrder { get; set; }
        public int EstimatedTimeInMinutes { get; set; }
        public int? StartDate { get; set; }
        public int? EndDate { get; set; }
        public int? CompletedDate { get; set; }
        public int IsBillable { get; set; }
        public int IsCompleted { get; set; }
        public int ShortDescription { get; set; }
        public string Version { get; set; }
        public string Uid { get; set; }
    }
}
