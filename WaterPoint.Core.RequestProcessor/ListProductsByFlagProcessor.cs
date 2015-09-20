using System.Collections.Generic;
using WaterPoint.Core.ContractMapper;
using WaterPoint.Core.Domain.Contracts.Products;
using WaterPoint.Core.Domain.SpecificationRequests.Products;
using WaterPoint.Core.Specification;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor
{
    public class ListProductsByFlagProcessor : BaseDapperUowRequestProcess<ListProductsByFlagRequest, IEnumerable<BasicProduct>>
    {
        private readonly ISpecification<ListProductsByFlagRequest, IEnumerable<Product>> _listProductsByFlagSpecification;

        public ListProductsByFlagProcessor(
            ISpecification<ListProductsByFlagRequest, IEnumerable<Product>> listProductsByFlagSpecification,
            IDapperUnitOfWork dapperUnitOfWork
            ) : base(dapperUnitOfWork)
        {
            _listProductsByFlagSpecification = listProductsByFlagSpecification;
        }

        public override IEnumerable<BasicProduct> GetResult(ListProductsByFlagRequest request)
        {
            using (DapperUnitOfWork.Begin())
            {
                var products = _listProductsByFlagSpecification.Run(DapperUnitOfWork.DbContext, request);

                return CoreMapperHelper.MapTo<IEnumerable<BasicProduct>>(products);
            }
        }
    }
}
