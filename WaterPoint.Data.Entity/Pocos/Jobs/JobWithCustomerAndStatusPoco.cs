using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.Entity.Attributes;

namespace WaterPoint.Data.Entity.Pocos.Jobs
{
    [Table("dbo", "Job", "j")]
    public class JobWithCustomerAndStatusPoco : IDataEntity
    {
        [Primary]
        public int Id{get;set;}
        [IgnoreMappingWhenUpdate]
        public int OrganizationId{get;set;}
        public int JobStatusId{get;set;}
        public int JobCategoryId{get;set;}
        public int Code{get;set;}
        public int ShortDescription{get;set;}
        public int LongDescription{get;set;}
        public int CustomerId{get;set;}
        public int StartDate{get;set;}
        public int EndDate{get;set;}
        public int DueDate{get;set;}
        public int ExcludeFromWip{get;set;}
        public int Version{get;set;}
        public int UtcCreated{get;set;}
        public int UtcUpdated{get;set;}
        public int Uid{get;set;}
        [Foreign]
        public string JobStatus { get; set; }
        [Foreign]
        public int? CustomerTypeId { get; set; }
        [Foreign]
        public string LastName { get; set; }
        [Foreign]
        public string FirstName { get; set; }
        [Foreign]
        public string OtherName { get; set; }
        public int TotalCount{get;set;}
    }
}
