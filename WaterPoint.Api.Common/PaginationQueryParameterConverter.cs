using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Api.Common
{

    public class SimplePaginationParameterConverter
    {
        public int PageSize { get; private set; }

        public int PageNumber { get; private set; }

        public SimplePaginationParameterConverter Convert(ISimplePagination paramter, string defaultSort)
        {
            PageSize = paramter.PageSize ?? 20;

            PageNumber = paramter.PageNumber ?? 1;

            return this;
        }
    }

    public class PaginationParameterConverter : SimplePaginationParameterConverter
    {
        public int Offset { get; private set; }

        public string Sort { get; private set; }

        public bool IsDesc { get; private set; }

        public string SearchTerm { get; private set; }

        public PaginationParameterConverter Convert(IPagination paramter, string defaultSort)
        {
            base.Convert(paramter, defaultSort);

            Offset = (((!paramter.PageNumber.HasValue || paramter.PageNumber < 0)
                ? 1
                : paramter.PageNumber.Value) - 1) * (paramter.PageSize ?? 20);

            Sort = string.IsNullOrWhiteSpace(paramter.Sort) ? defaultSort : paramter.Sort;
            IsDesc = paramter.IsDesc ?? false;
            SearchTerm = NeutralizeSearchString(paramter.SearchTerm);

            return this;
        }

        private static string NeutralizeSearchString(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return string.Empty;

            var searchCmd = SearchTermHelper.ConvertToSearchTerm(searchTerm);

            return searchCmd;
        }
    }
}
