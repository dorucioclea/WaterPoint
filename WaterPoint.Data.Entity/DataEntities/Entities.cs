
using System;

namespace WaterPoint.Data.Entity.DataEntities
{
    public class Address
    {
        public virtual int Id { get; set; }

        public virtual string Street { get; set; }

        public virtual string StreetExtraLine { get; set; }

        public virtual string Suburb { get; set; }

        public virtual string City { get; set; }

        public virtual string PostCode { get; set; }

        public virtual int CountryId { get; set; }

    }

    public class Category
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual DateTime CreatedOn { get; set; }

        public virtual DateTime UpdatedOn { get; set; }

    }

    public class Country
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Code { get; set; }

    }

    public class Credential
    {
        public virtual int Id { get; set; }

        public virtual int CustomerId { get; set; }

        public virtual string Email { get; set; }

        public virtual string Password { get; set; }

        public virtual DateTime CreatedOn { get; set; }

        public virtual DateTime UpdatedOn { get; set; }

    }


    public class Customer
    {
        public virtual int Id { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual string OtherName { get; set; }

        public virtual string MobilePhone { get; set; }

        public virtual DateTime? Dob { get; set; }

        public virtual Guid Uid { get; set; }

        public virtual DateTime CreatedOn { get; set; }

        public virtual DateTime UpdatedOn { get; set; }

    }


    public class Product
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public virtual DateTime CreatedOn { get; set; }

        public virtual DateTime UpdatedOn { get; set; }

    }


    public class Sku
    {
        public virtual int Id { get; set; }

        public virtual int ProductId { get; set; }

        public virtual string Code { get; set; }

        public virtual int Quantity { get; set; }

        public virtual DateTime CreatedOn { get; set; }

        public virtual DateTime UpdatedOn { get; set; }

    }


    public class SkuVariant
    {
        public virtual int Id { get; set; }

        public virtual int SkuId { get; set; }

        public virtual int VariantTypeId { get; set; }

        public virtual string TextValue { get; set; }

        public virtual decimal? NumberValue { get; set; }

    }


    public class VariantType
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

    }
}
