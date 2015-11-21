using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.OData;
using WaterPoint.Core.Domain.RequestDtos.Customers;

namespace WaterPoint.Core.Domain.RequestDtos
{
    public class PaginationWithOrgIdRequest : IRequest
    {
        public OrganizationIdParameter OrganizationIdParameter { get; set; }
        public PaginationParamter PaginationParamter { get; set; }
    }

    public class CreateCustomerRequest : IRequest
    {
        public OrganizationIdParameter OrganizationIdParameter { get; set; }
        public CreateCustomerPayload CreateCustomerPayload { get; set; }
    }

    public class UpdateCustomerRequest : IOrganizationEntityParameter, IRequest
    {
        public OrganizationEntityParameter OrganizationEntityParameter { get; set; }
        public Delta<UpdateCustomerPayload> UpdateCustomerPayload { get; set; }
    }

    public class GetCustomerByIdRequest : IOrganizationEntityParameter, IRequest
    {
        public OrganizationEntityParameter OrganizationEntityParameter { get; set; }
    }

    public interface IOrganizationEntityParameter
    {
        OrganizationEntityParameter OrganizationEntityParameter { get; set; }
    }
}
