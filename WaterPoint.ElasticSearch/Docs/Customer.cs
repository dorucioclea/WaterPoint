using Nest;

namespace WaterPoint.ElasticSearch.Docs
{
    [ElasticsearchType(Name = "customer")]
    public class Customer : EsDoc
    {
        [Boolean]
        public bool IsProspect { get; set; }

        [String]
        public string Code { get; set; }

        [String]
        public string FirstName { get; set; }

        [String]
        public string LastName { get; set; }

        [String]
        public string OtherName { get; set; }

        [String]
        public string Email { get; set; }
    }

    public class EsDoc
    {
        [Number(NumberType.Integer, Coerce = true, DocValues = true, Index = NonStringIndexOption.No)]
        public int Id { get; set; }

        [Number(NumberType.Integer, Coerce = true, DocValues = true, Index = NonStringIndexOption.No)]
        //[ElasticProperty(Index = FieldIndexOption.NotAnalyzed)]
        public int OrganizationId { get; set; }
    }
}
