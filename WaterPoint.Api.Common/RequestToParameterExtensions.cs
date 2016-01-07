using Utility;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Api.Common
{
    public static class RequestToParameterExtensions
    {
        public static T ConvertToParameter<T>(this IRequest request)
            where T : IQueryParameter, new()
        {
            var result = new T();

            request.MapTo(result);

            if (result is ISimplePagedQueryParameter && request is ISimplePagedRequest)
                (result as ISimplePagedQueryParameter).ConvertToPagedParameter(((ISimplePagedRequest)request), "Id");

            if (result is IPagedQueryParameter && request is IPaginationRequest)
                (result as IPagedQueryParameter).ConvertToPagedParameter(((IPaginationRequest)request), "Id");

            return result;
        }

        public static void ConvertToPagedParameter(
            this ISimplePagedQueryParameter source, ISimplePagedRequest request, string defaultSort)
        {
            if (source == null)
                return;

            source.PageSize = request.PageSize ?? 20;

            source.Offset = (((!request.PageNumber.HasValue || request.PageNumber < 0)
                ? 1
                : request.PageNumber.Value) - 1) * (request.PageSize ?? 20);

            source.PageNumber = request.PageNumber ?? 1;
        }

        public static void ConvertToPagedParameter(
            this IPagedQueryParameter source, IPaginationRequest request, string defaultSort)
        {
            if (source == null)
                return;

            (source as ISimplePagedQueryParameter).ConvertToPagedParameter(request, defaultSort);

            source.Sort = string.IsNullOrWhiteSpace(request.Sort) ? defaultSort : request.Sort;

            source.IsDesc = request.IsDesc ?? false;

            source.SearchTerm = NeutralizeSearchString(request.SearchTerm);
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
