using System.Web;
using System.Web.Mvc;

namespace Angkor.O7Web.Interface.Source
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
