using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Core.Contract
{
    [DataContract]
    public class OrganizationContract
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string DisplayName { get; set; }
        [DataMember]
        public int? LogoImageId { get; set; }
        [DataMember]
        public int? InvoiceDueDate { get; set; }
        [DataMember]
        public int? InvoiceDueDaysAfterInvoiced { get; set; }
        [DataMember]
        public string TaxCode { get; set; }
        [DataMember]
        public string InvoiceNote { get; set; }
        [DataMember]
        public string PurchaseOrderNote { get; set; }
        [DataMember]
        public string InvoiceNumberCode { get; set; }
        [DataMember]
        public string PurchaseOrderNumberCode { get; set; }
    }
}
