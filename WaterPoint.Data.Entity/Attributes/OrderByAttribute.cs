using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Data.Entity.Attributes
{
    public class OrderByAttribute : Attribute
    {
        public string Sort { get; private set; }

        public OrderByAttribute(string sort)
        {
            Sort = sort;
        }
    }
}
