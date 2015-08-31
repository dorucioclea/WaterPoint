using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
