using AutoMapper;
using WaterPoint.Core.Domain.Contracts.JobCategories;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts
{
    public class JobCategoriesMapper
    {
        static JobCategoriesMapper()
        {
            Mapper.CreateMap<JobCategory, JobCategoryContract>();
        }

        public static JobCategoryContract Map(JobCategory source)
        {
            return Mapper.Map<JobCategoryContract>(source);
        }
    }
}
