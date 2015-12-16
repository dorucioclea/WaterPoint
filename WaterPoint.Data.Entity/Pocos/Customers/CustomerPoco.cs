﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.Entity.Attributes;

namespace WaterPoint.Data.Entity.DataEntities
{
    [Table("dbo", "Customer", "c")]
    public class CustomerPoco : IDataEntity
    {
        [Primary]
        public int Id { get; set; }

        public int OrganizationId { get; set; }

        public int? CustomerTypeId { get; set; }

        public bool IsProspect { get; set; }

        public string Gender { get; set; }

        public string Code { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string OtherName { get; set; }

        public string Phone { get; set; }

        public string MobilePhone { get; set; }

        public string Email { get; set; }

        public DateTime? Dob { get; set; }

        public bool IsDeleted { get; set; }

        public int? InvoiceCustomerId { get; set; }

        public byte[] Version { get; set; }

        public Guid Uid { get; set; }

        public DateTime UtcCreated { get; set; }

        public DateTime UtcUpdated { get; set; }
    }
}
