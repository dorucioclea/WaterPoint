using AutoMapper;
using Utility;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Core.Domain.Contracts.Jobs;
using WaterPoint.Core.Domain.Contracts.JobStatuses;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.Jobs;

namespace WaterPoint.Core.ContractMapper
{
    public class JobMapper
    {
        static JobMapper()
        {
            Mapper.CreateMap<JobWithCustomerAndStatusPoco, JobWithCustomerAndStatusContract>()
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
                Id = source.Id,
                Name = source.JobStatus
            };
        }

        public static JobWithCustomerAndStatusContract Map(JobWithCustomerAndStatusPoco source)
        {
            return Mapper.Map<JobWithCustomerAndStatusContract>(source);
        }
    }
}
