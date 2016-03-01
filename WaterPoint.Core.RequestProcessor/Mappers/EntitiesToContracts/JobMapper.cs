using System;
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

        public static JobWithStatusContract Map(JobWithStatusPoco source)
        {
            var result = Mapper.DynamicMap<JobWithStatusContract>(source);

            result.Version = source.Version.ToSha1(source.Id.ToString());

            result.JobStatus = new JobStatusIdNameContract
            {
                Id = source.JobStatusId,
                Name = source.JobStatusName
            };

            return result;
        }

        public static JobDetailsContract Map(JobWithDetailsPoco source)
        {
            var result = Mapper.DynamicMap<JobDetailsContract>(source);

            result.Version = source.Version.ToSha1(source.Id.ToString());

            if (source.JobCategoryId.HasValue)
                result.Category = new JobCategoryContract
                {
                    Id = source.JobCategoryId.Value,
                    Description = source.JobCategoryDescription
                };

            if (source.PriorityTypeId.HasValue)
                result.Priority = new PriorityTypeContract
                {
                    Id = source.PriorityTypeId.Value,
                    Description = source.PriorityTypeDescription
                };

            result.Customer = new CustomerIdNameContract
            {
                Id = source.CustomerId,
                FirstName = source.CustomerFirstName,
                LastName = source.CustomerLastName,
                OtherName = source.CustomerOtherName

            };

            result.JobStatus = new JobStatusIdNameContract
            {
                Id = source.JobStatusId,
                Name = source.JobStatusName
            };

            return result;
        }
    }
}
