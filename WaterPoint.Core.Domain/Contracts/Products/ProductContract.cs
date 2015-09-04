using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Core.Domain.Contracts.Products
{
    public class ProductContract
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsActive { get; set; }

        public string Description { get; set; }

        public DateTime UtcCreatedOn { get; set; }

        public DateTime UtcUpdatedOn { get; set; }

        public IEnumerable<SkuContract> Skus { get; set; }

        //public  IList<Category> Categories { get; set; }

        public IList<FlagContract> Flags { get; set; }
    }

    public class FlagContract
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class SkuContract
    {
        public int Id { get; set; }

        public ProductContract Product { get; set; }

        public string Code { get; set; }

        public int Quantity { get; set; }

        public DateTime UtcCreatedOn { get; set; }

        public DateTime UtcUpdatedOn { get; set; }
    }
}
