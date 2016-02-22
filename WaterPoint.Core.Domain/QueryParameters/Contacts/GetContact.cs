using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.Contacts
{
    public class GetContact : IQueryParameter
    {
        public int OrganizationId { get; set; }
        public int Id { get; set; }
    }
}
