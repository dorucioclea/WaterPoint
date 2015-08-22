using AutoMapper;
using WaterPoint.Core.Contract;
using WaterPoint.Data.Entity;

namespace WaterPoint.Core.ContractMapper
{
    internal class TableProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Table, TableContract>();
        }
    }
}
