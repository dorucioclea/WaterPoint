using System;
using Microsoft.Build.Framework;

namespace WaterPoint.Core.Domain.Payloads.Suppliers
{
    public class CreateSupplierPayload : IPayload
    {
        [Required]
        public string Name { get; set; }

        public string Phone { get; set; }

        public string MobilePhone { get; set; }

        public string Email { get; set; }

        public string WebSite { get; set; }
    }
}
