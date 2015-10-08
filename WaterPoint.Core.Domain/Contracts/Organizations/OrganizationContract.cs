using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Core.Domain.Contracts.Organizations
{
    public class OrganizationContract
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string DisplayName { get; set; }
        public DateTime UtcCreated { get; set; }
        public DateTime UtcUpdated { get; set; }
        //public IList<ProductContract> Products { get; set; }
    }
}
