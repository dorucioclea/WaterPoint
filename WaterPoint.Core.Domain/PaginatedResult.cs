using WaterPoint.Core.Domain.Contracts;

namespace WaterPoint.Core.Domain
{
    public class PaginatedResult<T> : SimplePaginatedResult<T>
        where T: IContract
    {
        public string Sort { get; set; }
        public bool IsDesc { get; set; }
        //TODO:
        public int MaxId { get; set; }
    }
}
