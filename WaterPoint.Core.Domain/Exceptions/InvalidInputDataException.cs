using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WaterPoint.Core.Domain.Exceptions
{
    public class InvalidInputDataException : DetailedException
    {
        public InvalidInputDataException()
            : base("invalid input")
        {
        }
    }
}
