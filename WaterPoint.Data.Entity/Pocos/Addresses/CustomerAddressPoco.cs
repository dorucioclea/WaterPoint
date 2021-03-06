﻿using WaterPoint.Data.Entity.Attributes;

namespace WaterPoint.Data.Entity.Pocos.Addresses
{
    [Table("dbo", "Address", "ad")]
    public class CustomerAddressPoco : IDataEntity
    {
        [Primary]
        public int Id { get; set; }

        public int OrganizationId { get; set; }

        public string Street { get; set; }

        public string StreetExtraLine { get; set; }

        public string Suburb { get; set; }

        public string City { get; set; }

        public string Province { get; set; }

        public string PostCode { get; set; }

        public int CountryId { get; set; }

        public bool IsDeleted { get; set; }

        [OneToMany("dbo.CustomerAddress")]
        public int CustomerId { get; set; }

        [OneToMany("dbo.CustomerAddress")]
        public bool IsPrimary { get; set; }

        [OneToMany("dbo.CustomerAddress")]
        public bool IsPostAddress { get; set; }

        [AutoGenerated]
        public byte[] Version { get; set; }
    }
}
