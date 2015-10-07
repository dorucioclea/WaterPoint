using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Bll.Enum;

namespace WaterPoint.Core.Bll
{
    public interface ISqlBuilderFactory
    {
        ISqlBuilder Create(Crud action, Type idataEntityType);
    }
}
