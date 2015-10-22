﻿using System;
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
using WaterPoint.Core.Domain.Blls;
using WaterPoint.Core.RequestProcessor.Customers;
using WaterPoint.Core.Domain.Requests.Customers;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Core.Domain.Requests;
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
        }

        private void BindRequestProcessors()
        {
            Bind<IRequestProcessor<OrganizationIdRequest, PaginationRequest, PaginatedResult<IEnumerable<BasicCustomer>>>>()
                .To<PaginatedCustomersProcessor>();

            Bind<ICreateRequestProcessor<OrganizationIdRequest, CreateCustomerRequest, BasicCustomer>>()
                .To<CreateCustomerRequestProcessor>();
        }
    }
}
