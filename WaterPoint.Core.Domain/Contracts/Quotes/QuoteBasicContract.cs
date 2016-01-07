using System;

namespace WaterPoint.Core.Domain.Contracts.Quotes
{
    public class QuoteBasicContract : IContract
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public int QuoteStatusId { get; set; }
        public string Name { get; set; }
        public int? JobId { get; set; }
        public int CustomerId { get; set; }
        public string Code { get; set; }
        public bool IsFixedPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public string ShortDescription { get; set; }
        public string Version { get; set; }
    }
}
