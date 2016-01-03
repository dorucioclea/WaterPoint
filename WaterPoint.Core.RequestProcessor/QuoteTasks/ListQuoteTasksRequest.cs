using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;
using WaterPoint.Api.Common;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.QuoteTasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.Pocos.QuoteTasks;

namespace WaterPoint.Core.RequestProcessor.QuoteTasks
{
    //public class ListQuoteTasksRequestProcessor : ISimplePaginatedProcessor<ListQuoteTasksRequest, QuoteTaskBasicContract>
    //{
    //    private readonly IDapperUnitOfWork _dapperUnitOfWork;
    //    private readonly IListQueryRunner<ListQuoteTasks, QuoteTaskBasicPoco> _paginatedQuoteTaskRunner;
    //    private readonly PaginationQueryParameterConverter _paginationQueryParameterConverter;
    //    private readonly IQuery<ListQuoteTasks> _paginatedQuoteTasksQuery;

    //    public ListQuoteTasksProcessor(
    //        IDapperUnitOfWork dapperUnitOfWork,
    //        IListQueryRunner<ListQuoteTasks, QuoteTaskBasicPoco> paginatedQuoteTaskRunner,
    //        PaginationQueryParameterConverter paginationQueryParameterConverter,
    //        IQuery<ListQuoteTasks> paginatedQuoteTasksQuery)
    //    {
    //        _dapperUnitOfWork = dapperUnitOfWork;
    //        _paginatedQuoteTaskRunner = paginatedQuoteTaskRunner;
    //        _paginationQueryParameterConverter = paginationQueryParameterConverter;
    //        _paginatedQuoteTasksQuery = paginatedQuoteTasksQuery;
    //    }

    //    public QuoteTaskBasicContract Map(QuoteTaskBasicPoco source)
    //    {
    //        return QuoteTaskMapper.Map(source);
    //    }

    //    public SimplePaginatedResult<QuoteTaskBasicContract> Process(ListQuoteTasksRequestProcessor input)
    //    {
    //        var parameter = _paginationQueryParameterConverter.Convert(input.Pagination, "Id")
    //            .MapTo(new ListQuoteTasks());

    //        parameter.OrganizationId = input.Parameter.OrganizationId;
    //        parameter.JobId = input.Parameter.JobId;

    //        _paginatedQuoteTasksQuery.BuildQuery(parameter);

    //        using (_dapperUnitOfWork.Begin())
    //        {
    //            var result = _paginatedQuoteTaskRunner.Run(_paginatedQuoteTasksQuery);

    //            return (result != null)
    //                ? new SimplePaginatedResult<QuoteTaskBasicContract>
    //                {
    //                    Data = result.Data.Select(Map),
    //                    TotalCount = result.TotalCount,
    //                    PageNumber = _paginationQueryParameterConverter.PageNumber,
    //                    PageSize = _paginationQueryParameterConverter.PageSize
    //                }
    //                : null;
    //        }
    //    }
    //}

}
