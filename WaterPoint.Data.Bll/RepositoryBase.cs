using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.Repository;

namespace WaterPoint.Data.Bll
{
    public abstract class BllBase
    {
        protected IDbContext Repo { get; set; }

        protected BllBase(IDbContext repo)
        {
            Repo = repo;
        }
    }
}
