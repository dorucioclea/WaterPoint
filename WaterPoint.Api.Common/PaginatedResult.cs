using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Api.Common
{
    public class PaginatedResult<T>
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
        //TODO:
        public int MaxId { get; set; }
        public T Data { get; set; }
    }
}
