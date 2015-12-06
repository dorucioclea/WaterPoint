using WaterPoint.Core.Bll;
using WaterPoint.Core.Domain.Dtos;

namespace WaterPoint.Core.RequestProcessor
{
    public class PaginationAnalyzer
    {
        public int Offset { get; private set; }

        public int PageSize { get; private set; }

        public int PageNumber { get; private set; }

        public string Sort { get; private set; }

        public bool IsDesc { get; private set; }

        public string SearchTerm { get; private set; }

        public void Analyze(PaginationParamter paramter, string defaultSort)
        {
            Offset = (((!paramter.PageNumber.HasValue || paramter.PageNumber < 0)
                ? 1
                : paramter.PageNumber.Value) - 1) * (paramter.PageSize ?? 20);
            PageSize = paramter.PageSize ?? 20;
            PageNumber = paramter.PageNumber ?? 1;
            Sort = string.IsNullOrWhiteSpace(paramter.Sort) ? defaultSort : paramter.Sort;
            IsDesc = paramter.IsDesc ?? false;
            SearchTerm = NeutralizeSearchString(paramter.SearchTerm);
        }

        private static string NeutralizeSearchString(string searchTerm)
        {
            if (!Search.IsSearchable(searchTerm))
                return string.Empty;

            var freetext = Search.TokenizeSearchTerm(searchTerm);
            var searchCmd = Search.CreateSearchCmd(freetext);

            return searchCmd;
        }
    }
}
