using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Utils;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Repositories;
using WaterPoint.Core.Repository;
using WaterPoint.Data.DbContext;
using WaterPoint.Data.DbContext.NHibernate;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(
            ISessionUnitOfWork sessionUnitOfWork)
            : base(sessionUnitOfWork)
        {
        }

        public IList<Product> ListProductsByFlag(int flagId)
        {
            var result = Session.QueryOver<Product>()
                .Where(p=>p.IsActive && !p.IsDeleted)
                .JoinQueryOver<Flag>(p => p.Flags)
                .Where(f => f.Id == flagId)
                .List();

            return result;
        }
    }
}
