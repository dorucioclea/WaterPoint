using AutoMapper;
using Utility;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Core.Domain.Contracts.JobCategories;
using WaterPoint.Core.Domain.Contracts.Jobs;
using WaterPoint.Core.Domain.Contracts.JobStatuses;
using WaterPoint.Data.Entity.Pocos.Jobs;

namespace WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts
{
    public class JobMapper
    {
        static JobMapper()
        {
            Mapper.CreateMap<JobWithCustomerAndStatusPoco, JobWithCustomerContract>()
                .ForMember(o => o.Version, i => i.MapFrom(d => d.Version.ToSha1(d.Id.ToString())))
                .ForMember(o => o.Customer, i => i.ResolveUsing(MapCustomer))
                .ForMember(o => o.JobStatus, i => i.ResolveUsing(MapJobStatus));
        }

        private static object MapCustomer(JobWithCustomerAndStatusPoco source)
        {
            return new CustomerIdNameContract
            {
                Id = source.CustomerId,
                FirstName = source.FirstName,
                LastName = source.LastName,
                OtherName = source.OtherName
            };
        }

        private static object MapJobStatus(JobWithCustomerAndStatusPoco source)
        {
            return new JobStatusIdNameContract
            {
                Id = source.JobStatusId,
                Name = source.JobStatus
            };
        }

        public static JobWithCustomerContract Map(JobWithCustomerAndStatusPoco source)
        {
            return Mapper.Map<JobWithCustomerContract>(source);
        }

        public static JobWithDetailsContract Map(JobWithDetailsPoco source)
        {
            var result = Mapper.DynamicMap<JobWithDetailsContract>(source);

            result.Category = Mapper.DynamicMap<JobCategoryIdDescContract>(new
            {
                Id = source.JobCategoryId,
                Description = source.JobCategoryDescription
            });

            result.Priority = Mapper.DynamicMap<PriorityTypeContract>(new
            {
                Id = source.PriorityTypeId,
                Description = source.PriorityTypeDescription
            });

            result.Customer = Mapper.DynamicMap<CustomerIdNameContract>(new
            {
                Id = source.CustomerId,
                FirstName = source.CustomerFirstName,
                LastName = source.CustomerLastName,
                OtherName = source.CustomerOtherName

            });
            result.JobStatus = Mapper.DynamicMap<JobStatusIdNameContract>(new
            {
                Id = source.JobStatusId,
                Name = source.JobStatusName
            });

            return result;
        }
    }
}
