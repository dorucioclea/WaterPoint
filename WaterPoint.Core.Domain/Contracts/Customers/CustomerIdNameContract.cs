namespace WaterPoint.Core.Domain.Contracts.Customers
{
    public class CustomerIdNameContract : IContract
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherName { get; set; }
    }
}
