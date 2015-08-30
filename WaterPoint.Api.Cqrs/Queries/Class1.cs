using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Api.Cqrs.Queries
{
    

    public class GetProductsByFlag : IQuery
    {
        public int FlagId { get; private set; }

        public GetProductsByFlag(int flagId)
        {
            FlagId = flagId;
        }
    } 
}
