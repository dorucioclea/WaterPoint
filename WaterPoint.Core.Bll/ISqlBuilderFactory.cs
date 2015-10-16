using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.Entity;

namespace WaterPoint.Core.Bll
{
    public interface ISqlBuilderFactory
    {
        T Create<T>() where T : ISqlBuilder;
    }
}
