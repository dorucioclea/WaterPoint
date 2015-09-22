using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.ContractMapper;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Contracts.Products;
using WaterPoint.Core.Domain.Repositories;
using WaterPoint.Core.Domain.SpecificationRequests.Products;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.Specification.Products
{
    public class ListProductByFlagSpecification : ISpecification<ListProductsByFlagRequest, IEnumerable<Product>>
    {
        //need to pass in column names as variable so in case of changing the entity.
        private const string Sql = @"
            SELECT
                p.Id,
                p.Name
            FROM dbo.Product p
                JOIN dbo.ProductFlag pf ON pf.ProductId = p.Id
            WHERE p.shopid = @shopId
                AND pf.FlagId = @flagId";

        public IEnumerable<Product> RunQuery(IDapperDbContext dbContext, ListProductsByFlagRequest request)
        {
            return dbContext.List<Product>(
                Sql,
                new
                {
                    shopId = request.ShopId,
                    flagId = request.FlagId
                });
        }
    }
}
