using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Core.Contract
{
    public class OrganizationContract
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string DisplayName { get; set; }
        
        public int? LogoImageId { get; set; }
        
        public int? InvoiceDueDate { get; set; }
        
        public int? InvoiceDueDaysAfterInvoiced { get; set; }
        
        public string TaxCode { get; set; }
        
        public string InvoiceNote { get; set; }
        
        public string PurchaseOrderNote { get; set; }
        
        public string InvoiceNumberCode { get; set; }
        
        public string PurchaseOrderNumberCode { get; set; }
    }
}
