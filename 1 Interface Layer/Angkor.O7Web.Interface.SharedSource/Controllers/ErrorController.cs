using System.Web.Mvc;

namespace Angkor.O7Web.Interface.SharedSource.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Error401()
        {
            return View();
        }

        public ActionResult Error404()
        {
            return View();
        }

        public ActionResult Error500()
        {
            return View();
        }
    }
}