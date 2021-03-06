﻿using System;

namespace WaterPoint.Core.Domain.Contracts.Customers
{
    public class CustomerContract : IContract
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public int? CustomerTypeId { get; set; }
        public bool IsProspect { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public DateTime? Dob { get; set; }
        public string Version { get; set; }
        public DateTime UtcCreated { get; set; }
        public DateTime UtcUpdated { get; set; }
        public string Uid { get; set; }
    }
}
