using WaterPoint.Core.Domain.Dtos;

namespace WaterPoint.Core.Domain
{
    public class PaginatedResult<T> : IContract
    {
        public int TotalPages
        {
            get
            {
                var totalPages = TotalCount / ((PageSize == 0) ? 1 : PageSize);

                var reminder = TotalCount % PageSize > 0;

                if (reminder)
                    totalPages += 1;

                return totalPages;
            }
        }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public string Sort { get; set; }
        public bool IsDesc { get; set; }
        //TODO:
        public int MaxId { get; set; }
        public T Data { get; set; }
    }
}
