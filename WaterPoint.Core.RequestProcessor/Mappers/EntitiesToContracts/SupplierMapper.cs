using AutoMapper;
using Utility;
using WaterPoint.Core.Domain.Contracts.Suppliers;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts
{
    public class SupplierMapper
    {
        static SupplierMapper()
        {
            Mapper.CreateMap<Supplier, SupplierContract>()
                .ForMember(o => o.Version, i => i.MapFrom(d => d.Version.ToSha1(d.Id.ToString())));
        }

        public static SupplierContract Map(Supplier source)
        {
            return Mapper.Map<SupplierContract>(source);
        }
    }
}