using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WaterPoint.Api.Common.BaseControllers
{
    public class BaseOrgnizationContextController : ApiController
    {
        public StaffContext Staff
        {
            get
            {
                return new StaffContext
                {
                    Id = 10000
                };
            }
        }
    }

    public class StaffContext
    {
        public int Id { get; set; }
    }
}
