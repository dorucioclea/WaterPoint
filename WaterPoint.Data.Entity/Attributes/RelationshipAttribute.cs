using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Remotion.Linq.Utilities;

namespace WaterPoint.Data.Entity.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class RelationshipAttribute : Attribute
    {
        public Type Type { get; private set; }

        protected RelationshipAttribute(Type type)
        {
            if (type != typeof(IDataEntity))
                throw new ArgumentTypeException("Wrong type", "type", typeof(IDataEntity), type);

            Type = type;
        }
    }
}
