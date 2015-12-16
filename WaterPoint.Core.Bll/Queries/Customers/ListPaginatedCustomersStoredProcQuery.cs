using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.Bll.Queries.Customers
{
    public class ListPaginatedCustomersStoredProcQuery : IPaginatedWithOrgIdQuery
    {
        public void BuildQuery(int orgId, int offset, int pageSize, string orderBy, bool isDesc, string searchTerm)
        {
            var storedProc = string.IsNullOrWhiteSpace(searchTerm)
                ? "dbo.List_Customers_Paginated"
                : "dbo.List_Customers_Paginated_WithSearch";

            Query = storedProc;

            Parameters = new
            {
                orgId,
                offset,
                pageSize,
                searchTerm
            };
        }
        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
