using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;

namespace WaterPoint.Core.Cqrs.Queries
{
    public class ListProductsByFlagQuery : IQuery
    {
        public int FlagId { get; set; }
    }
}
