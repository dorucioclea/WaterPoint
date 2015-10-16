using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using WaterPoint.Api.Common;
using WaterPoint.Core.Bll.Customers;
using WaterPoint.Core.Bll.Customers.Queries;
using WaterPoint.Core.Bll.Customers.Runners;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Blls;
using WaterPoint.Core.RequestProcessor.Customers;
using WaterPoint.Core.Domain.Requests.Customers;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Core.Domain.Requests;

namespace WaterPoint.Api.DependencyInjection
{
    public class CustomerApiModule : NinjectModule
    {
        public override void Load()
        {
            BindRequestProcessors();
            BindBlls();
        }

        private void BindBlls()
        {
            Bind<PaginatedCustomersQuery>().ToSelf();
            Bind<PaginatedCustomerQueryRunner>().ToSelf();
            Bind<PaginationAnalyzer>().ToSelf();
        }

        private void BindRequestProcessors()
        {
            Bind<IRequestProcessor<OrganizationIdRequest, PaginationRequest, PaginatedResult<IEnumerable<BasicCustomer>>>>()
                .To<PaginatedCustomersProcessor>();
        }
    }
}
