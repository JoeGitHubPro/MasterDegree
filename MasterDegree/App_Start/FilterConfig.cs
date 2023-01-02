using System.Web;
using System.Web.Mvc;

namespace MasterDegree
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            // to privent public from enter website 
           // filters.Add(new AuthorizeAttribute());
        }
    }
}
