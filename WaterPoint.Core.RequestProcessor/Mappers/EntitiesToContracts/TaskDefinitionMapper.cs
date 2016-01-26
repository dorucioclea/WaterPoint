using AutoMapper;
using Utility;
using WaterPoint.Core.Domain.Contracts.TaskDefinitions;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.TaskDefinitions;

namespace WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts
{
    public class TaskDefinitionMapper
    {
        static TaskDefinitionMapper()
        {
            Mapper.CreateMap<TaskDefinition, TaskDefinitionContract>()
                .ForMember(o => o.Version, i => i.MapFrom(d => d.Version.ToSha1(d.Id.ToString())));

            Mapper.CreateMap<TaskDefinitionBasicPoco, TaskDefinitionBasicContract>()
                .ForMember(o => o.Version, i => i.MapFrom(d => d.Version.ToSha1(d.Id.ToString())));
        }

        public static TaskDefinitionContract Map(TaskDefinition source)
        {
            return Mapper.Map<TaskDefinitionContract>(source);
        }

        public static TaskDefinitionBasicContract Map(TaskDefinitionBasicPoco source)
        {
            return Mapper.Map<TaskDefinitionBasicContract>(source);
        }
    }
}
