﻿namespace WaterPoint.Core.Domain.Contracts.Addresses
{
    public class AddressContract : IContract
    {
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

        public string Version { get; set; }
    }
}