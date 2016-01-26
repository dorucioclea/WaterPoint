using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Suppliers;
using WaterPoint.Core.Domain.Requests.Suppliers;
using WaterPoint.Data.DbContext.Dapper;
using Utility;
using WaterPoint.Core.Domain.QueryParameters.Suppliers;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.Suppliers
{
    public class CreateSupplierProcessor : BaseCreateProcessor<CreateSupplierRequest, CreateSupplier>
    {
        public CreateSupplierProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<CreateSupplier> command,
            ICommandExecutor<CreateSupplier> executor)
            : base(dapperUnitOfWork, command, executor)
        {
        }

        public override CreateSupplier BuildParameter(CreateSupplierRequest input)
        {
            var createSupplier = input.Payload.MapTo(new CreateSupplier());

            createSupplier.OrganizationId = input.OrganizationId;

            return createSupplier;
        }
    }
}
