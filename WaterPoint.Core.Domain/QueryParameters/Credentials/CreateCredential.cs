using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.Credentials
{
    public class CreateCredential : IQueryParameter
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
