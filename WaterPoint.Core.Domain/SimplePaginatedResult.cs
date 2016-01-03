using System.Collections.Generic;
using WaterPoint.Core.Domain.Contracts;

namespace WaterPoint.Core.Domain
{
    public class SimplePaginatedResult<T>
        where T : IContract
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
        public IEnumerable<T> Data { get; set; }
    }
}
