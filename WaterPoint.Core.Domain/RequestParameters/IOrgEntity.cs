namespace WaterPoint.Core.Domain.RequestParameters
{
    public interface IOrgId
    {
        int OrganizationId { get; set; }
    }

    public interface IOrgEntity : IOrgId
    {
        int Id { get; set; }
    }
}
