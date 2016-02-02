namespace WaterPoint.Core.Domain.Contracts.Staff
{
    public interface IBasicStaffContract : IContract
    {
        int Id { get; set; }
        int OrganizationId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string OtherName { get; set; }
    }
}
