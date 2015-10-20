using System;
using System.Linq;
using System.Reflection;
using WaterPoint.Core.Domain.Requests;

namespace WaterPoint.Api.Common
{
    public class PaginationAnalyzer
    {
        public int Offset { get; private set; }

        public int PageSize { get; private set; }

        public int PageNumber { get; private set; }

        public string Sort { get; private set; }

        public void Analyze(PaginationRequest request)
        {
            Offset = (((!request.PageNumber.HasValue || request.PageNumber < 0)
                ? 1
                : request.PageNumber.Value) - 1) * (request.PageSize ?? 20);
            PageSize = request.PageSize ?? 20;
            PageNumber = request.PageNumber ?? 1;
            Sort = request.Sort;
        }
    }
}
