using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain.SpecificationRequests;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.Specification
{
    public interface ISpecification<in TI, out TOut>
        where TI : ISpecificationRequest
    {
        TOut RunQuery(IDapperDbContext dbConnection, TI ti);
    }
}
