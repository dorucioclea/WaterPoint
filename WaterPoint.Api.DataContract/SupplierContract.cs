using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Api.Contract
{
    [DataContract]
    public class SupplierContract
    {
        public int Id { get; set; }

        [DataMember(Name = "id")]
        public string Uid { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string DisplayName { get; set; }

        [DataMember]
        public string Mobile { get; set; }

        [DataMember]
        public string Phone1 { get; set; }
    }
}
