using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.ElasticSearch.Docs
{
    public enum DocChangeTypes
    {
        EditOrCreate,
        Remove
    }



    public class DocChange<T> where T : EsDoc
    {
        public DocChangeTypes Type { get; set; }

        public string DocTypeName { get; set; }

        public T Doc { get; set; }
    }
}
