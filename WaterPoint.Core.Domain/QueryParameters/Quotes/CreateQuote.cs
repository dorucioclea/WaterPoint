﻿using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.Quotes
{
    public class CreateQuote : IQueryParameter
    {
        public int OrganizationId { get; set; }
        public int QuoteStatusId { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public int? JobId { get; set; }
        public int? ContactId { get; set; }
        public string Code { get; set; }
        public string ShortDescription { get; set; }
        public string LongDesscription { get; set; }
    }
}
