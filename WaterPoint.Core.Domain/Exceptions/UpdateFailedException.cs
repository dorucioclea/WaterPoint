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
    public class UpdateFailedException : DetailedException
    {
        public UpdateFailedException()
            : base("cannot update the object.")
        {
        }
    }

    public class DetailedException : Exception
    {
        public DetailedException(string msg)
            : base(msg)
        {
            Messages = new List<string>();
        }

        public IList<string> Messages { get; }

        public void AddMessage(string message)
        {
            Messages.Add(message);
        }
    }
}
