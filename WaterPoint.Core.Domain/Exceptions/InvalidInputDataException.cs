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
    public class InvalidInputDataException : Exception
    {
        public InvalidInputDataException()
            : base("invalid input.")
        {
        }

        public IList<string> Messages { get; private set; }

        public void AddMessage(string message)
        {
            Messages.Add(message);
        }
    }
}
