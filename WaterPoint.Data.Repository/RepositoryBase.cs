﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.DbContext;
using WaterPoint.Data.Entity;
using WaterPoint.Data.Repository.Interfaces;

namespace WaterPoint.Data.Repository
{
    public abstract class RepositoryBase<T>
        where T : class
    {
        protected IDbContext DbContext { get; set; }

        protected RepositoryBase(IDbContext dbContext)
        {
            DbContext = dbContext;
        }

        protected T Save()
        {
            throw new NotImplementedException();
        }
    }
}
