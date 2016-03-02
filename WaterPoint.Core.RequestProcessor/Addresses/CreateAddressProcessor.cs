using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Addresses;
using WaterPoint.Core.Domain.Requests.Addresses;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.RequestProcessor.Addresses
{
    public class CreateAddressProcessor :
        BaseCreateProcessor<CreateAddressRequest, CreateAddress>
    {
        public CreateAddressProcessor(
           IDapperUnitOfWork dapperUnitOfWork,
           ICommand<CreateAddress> command,
           ICommandExecutor executor)
            : base(dapperUnitOfWork, command, executor)
        {
        }

        public override CreateAddress BuildParameter(CreateAddressRequest input)
        {
            return new CreateAddress
            {
                OrganizationId = input.OrganizationId,
                IsDeleted = input.Payload.IsDeleted,
                City = input.Payload.City,
                CountryId = input.Payload.CountryId,
                PostCode = input.Payload.PostCode,
                Province = input.Payload.Province,
                Street = input.Payload.Street,
                StreetExtraLine = input.Payload.StreetExtraLine,
                Suburb = input.Payload.Suburb
            };
        }
    }
}
