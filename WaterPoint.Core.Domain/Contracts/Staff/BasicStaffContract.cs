namespace WaterPoint.Core.Domain.Contracts.Staff
{
    public class BasicStaffContract : IBasicStaffContract
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherName { get; set; }
        public string Version { get; set; }
    }
}
