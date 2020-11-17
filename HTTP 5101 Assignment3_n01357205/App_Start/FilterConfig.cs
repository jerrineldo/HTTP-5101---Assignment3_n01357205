using System.Web;
using System.Web.Mvc;

namespace HTTP_5101_Assignment3_n01357205
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
