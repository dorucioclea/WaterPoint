using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Bll.Enum;
using WaterPoint.Data.Entity;

namespace WaterPoint.Core.Bll
{
    public interface ISqlBuilderFactory
    {
        ISqlBuilder<T> Create<T>(Crud action) where T : IDataEntity;
    }
}
