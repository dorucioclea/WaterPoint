using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using WaterPoint.Api.Common;
using WaterPoint.Core.Bll;
using WaterPoint.Core.Bll.Customers;
using WaterPoint.Core.Bll.Customers.Commands;
using WaterPoint.Core.Bll.Customers.Queries;
using WaterPoint.Core.Bll.Customers.Runners;
using WaterPoint.Core.Domain;
using WaterPoint.Core.RequestProcessor.Customers;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Core.Domain.Dtos;
using WaterPoint.Core.Domain.Dtos.Customers;
using WaterPoint.Core.Domain.Dtos.Customers.Requests;
using WaterPoint.Core.RequestProcessor;

namespace WaterPoint.Api.DependencyInjection
{
    public class CustomerApiModule : NinjectModule
    {
        public override void Load()
        {
            BindRequestProcessors();
            BindQueriesAndCommands();
        }

        private void BindQueriesAndCommands()
        {
            Bind<PaginatedCustomersQuery>().ToSelf();
            Bind<PaginatedCustomerRunner>().ToSelf();
            Bind<PaginationAnalyzer>().ToSelf();
            Bind<CreateCustomersCommand>().ToSelf();
            Bind<CreateCommandExecutor>().ToSelf();
            Bind<GetCustomerByIdQueryRunner>().ToSelf();
        }

        private void BindRequestProcessors()
        {
            Bind<IRequestProcessor<PaginationWithOrgIdRequest, PaginatedResult<IEnumerable<CustomerContract>>>>()
                .To<PaginatedCustomersProcessor>();
            Bind<IRequestProcessor< CreateCustomerRequest, CustomerContract >>()
                    .To<CreateCustomerRequestProcessor>();
            Bind<IRequestProcessor<UpdateCustomerRequest, CustomerContract>>()
                .To<UpdateCustomerRequestProcessor>();
            Bind<IRequestProcessor<GetCustomerByIdRequest, CustomerContract>>()
                .To<GetCustomerByIdRequestProcessor>();
       
        }
    }
}
