using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.ApiClient;
using WaterPoint.App.Domain;
using WaterPoint.App.Domain.ApiContracts;
using WaterPoint.App.Domain.ViewModels.Customers;
using WaterPoint.App.Domain.ViewModels.Customers.Partials;
using WaterPoint.App.ViewModelMapper;

namespace WaterPoint.App.Service.Customer
{
    public interface ICustomerService
    {
        Task<CustomerHomeIndex> GetCustomerHomeIndex(int orgId);
    }

    public class CustomerService : ICustomerService
    {
        private readonly IApiClient _apiClient;
        private readonly IApiContractToViewModelMapper _mapper;

        public CustomerService(
            IApiClient apiClient,
            IApiContractToViewModelMapper mapper)
        {
            _apiClient = apiClient;
            _mapper = mapper;
        }

        public async Task<CustomerHomeIndex> GetCustomerHomeIndex(int orgId)
        {
            var result = await _apiClient.SetUri(ApiV1.Customers.List(orgId))
                .Get<IEnumerable<BasicCustomer>>();

            var customers = _mapper.MapTo<IEnumerable<BasicCustomerInfo>>(result);

            var customerHomeIndex = new CustomerHomeIndex
            {
                Customers = customers
            };

            return customerHomeIndex;
        }
    }
}
