using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using WaterPoint.Core.Bll.Customers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Blls;
using WaterPoint.Core.RequestProcessor.Customers;
using WaterPoint.Core.Domain.Requests.Customers;
using WaterPoint.Core.Domain.Contracts.Customers;

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
            Bind<IBasicCustomerBll>().To<BasicCustomerPocoBll>();
        }

        private void BindRequestProcessors()
        {
            Bind<IRequestProcessor<PaginatedCustomersRequest, IEnumerable<BasicCustomer>>>()
                .To<PaginatedCustomersProcessor>();
        }
    }
}
