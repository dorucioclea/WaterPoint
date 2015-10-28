using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Data.Entity.Attributes
{
    public class ManyToManyAttribute : Attribute
    {
        public string ViaTable{ get; private set; }

        public string ThisOn { get; private set; }

        public string OtherOn { get; private set; }

        public ManyToManyAttribute(string viaTable, string thisOn, string otherOn)
        {
            ViaTable =  viaTable;
            ThisOn = thisOn;
            OtherOn = otherOn;
        }
    }
}
