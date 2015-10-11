using System.Web;
using System.Web.Mvc;

namespace WaterPoint.Api.BaseSite
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
