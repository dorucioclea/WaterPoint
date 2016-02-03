using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.Domain.Contracts.Suppliers;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Suppliers;
using WaterPoint.Core.Domain.Requests.Suppliers;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.Suppliers
{
    public class ListSuppliersProcessor :
        PagedProcessor<ListSuppliersRequest, ListSuppliers, Supplier, SupplierContract>
    {
        public ListSuppliersProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<ListSuppliers, Supplier> listQuery,
            IPagedQueryRunner listQueryRunner)
            : base(dapperUnitOfWork, listQuery, listQueryRunner)
        {
        }

        public override SupplierContract Map(Supplier source)
        {
            return SupplierMapper.Map(source);
        }
    }
}
