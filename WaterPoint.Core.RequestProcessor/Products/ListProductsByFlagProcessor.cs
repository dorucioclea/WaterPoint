using System.Collections.Generic;
using WaterPoint.Core.ContractMapper;
using WaterPoint.Core.Domain.Contracts.Products;
using WaterPoint.Core.Domain.SpecificationRequests.Products;
using WaterPoint.Core.Specification;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.Products
{
    public class ListProductsByFlagProcessor : BaseDapperUowRequestProcess<ListProductsByFlagRequest, IEnumerable<BasicProduct>>
    {
        private readonly ISpecification<ListProductsByFlagRequest, IEnumerable<Product>> _listProductsByFlagSpecification;
        private readonly ICoreMapper _coreMapper;

        public ListProductsByFlagProcessor(
            ISpecification<ListProductsByFlagRequest, IEnumerable<Product>> listProductsByFlagSpecification,
            ICoreMapper coreMapper,
            IDapperUnitOfWork dapperUnitOfWork)
            : base(dapperUnitOfWork)
        {
            _listProductsByFlagSpecification = listProductsByFlagSpecification;
            _coreMapper = coreMapper;
        }

        public override IEnumerable<BasicProduct> GetResult(ListProductsByFlagRequest request)
        {
            using (DapperUnitOfWork.Begin())
            {
                var products = _listProductsByFlagSpecification.RunQuery(DapperUnitOfWork.DbContext, request);

                return _coreMapper.MapTo<IEnumerable<BasicProduct>>(products);
            }
        }
    }
}
