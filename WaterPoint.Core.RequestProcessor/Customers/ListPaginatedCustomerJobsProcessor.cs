using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Jobs;
using WaterPoint.Core.Domain.Dtos.Requests.Customers;

namespace WaterPoint.Core.RequestProcessor.Customers
{
    public class ListPaginatedCustomerJobsProcessor : IRequestProcessor<ListPaginatedCustomerJobsRequest, JobWithCustomerAndStatusContract>
    {
        public JobWithCustomerAndStatusContract Process(ListPaginatedCustomerJobsRequest input)
        {
            throw new NotImplementedException();
        }
    }
}
