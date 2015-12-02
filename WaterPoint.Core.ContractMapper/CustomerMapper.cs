using AutoMapper;
using Utility;
using WaterPoint.Core.Domain.Contracts.TaskDefinitions;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.ContractMapper
{
    public class TaskDefinitionMapper
    {
        static TaskDefinitionMapper()
        {
            Mapper.CreateMap<TaskDefinition, TaskDefinitionContract>()
                .ForMember(o => o.Version, i => i.MapFrom(d => d.Version.ToSha1(d.Id.ToString())));
        }

        public static TaskDefinitionContract Map(TaskDefinition source)
        {
            return Mapper.Map<TaskDefinitionContract>(source);
        }
    }
}
