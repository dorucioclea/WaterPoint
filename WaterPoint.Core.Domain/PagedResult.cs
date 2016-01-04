using WaterPoint.Core.Domain.Contracts;

namespace WaterPoint.Core.Domain
{
    public class PagedResult<T> : SimplePagedResult<T>
        where T: IContract
    {
        public string Sort { get; set; }
        public bool IsDesc { get; set; }
        //TODO:
        public int MaxId { get; set; }
    }
}
