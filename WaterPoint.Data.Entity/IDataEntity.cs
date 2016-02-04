using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.Entity.Attributes;

namespace WaterPoint.Data.Entity
{
    public interface IDataEntity
    {
    }

    public interface ITrackUpdateTime
    {
        DateTime UtcUpdated { get; set; }
    }
}
