using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;

namespace WaterPoint.Api.Invoice.Controllers
{
    public class JobInvoicesController : BaseOrgnizationContextController
    {
        public JobInvoicesController(
            IRequestProcessor<CreateJobInvoiceRequest, CommandResultContract> createProcessor)
        {

        }
    }
}
