using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public ProductRepository(ISessionUnitOfWork sessionUnitOfWork,
            IQueryDispatcher queryDispatcher,
            ICommandDispatcher commandDispatcher)
            : base(sessionUnitOfWork)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        public T Run<T>(IQuery query)
        {
            return _queryDispatcher.Dispatch<T>(query);
        }

        public int Execute(ICommand command)
        {
            return _commandDispatcher.Execute(command);
        }

        public class ProductQueryDispatcher : IQueryDispatcher
        {

            public IQuery Query
            {
                get { throw new NotImplementedException(); }
            }

            public T Dispatch<T>(IQuery query)
            {
                throw new NotImplementedException();
            }
        }
    }
}
