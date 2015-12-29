using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace WaterPoint.Api.Common.Attributes
{
    public enum Privileges
    {
        AddCus = 1,
        DelCus = 2,
        EditCus = 3,
        ViewCus = 4,
        AddJob = 5,
        DelJob = 6,
        EditJob = 7,
        ViewJob = 8,
        AddCost = 9,
        DelCost = 10,
        EditCost = 11,
        ViewCost = 12,
        AddTask = 13,
        DelTask = 14,
        EditTask = 15,
        ViewTask = 16,
        AddJobTime = 17,
        DelJobTime = 18,
        EditJobTime = 19,
        ViewJobTime = 20
    }

    public class RequirePrivilege : ActionFilterAttribute
    {
        public RequirePrivilege()
        {

        }
    }
}
