using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Data.Entity.Attributes
{
    public class OneToManyAttribute : Attribute
    {
        public string On { get; private set; }

        public OneToManyAttribute(string on)
        {
            On = on;
        }
    }
}
