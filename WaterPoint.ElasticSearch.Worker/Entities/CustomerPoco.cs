namespace WaterPoint.ElasticSearch.Worker.Entities
{
    public class CustomerPoco : ISearableEntity
    {
        public int Id { get; set; }

        public int? LastChangeOrganizationUserId { get; set; }

        public int OrganizationId { get; set; }

        public bool IsProspect { get; set; }

        public string Code { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string OtherName { get; set; }

        public string Email { get; set; }
    }
}
