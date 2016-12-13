using System.Web.Mvc;

namespace Angkor.O7Web.Interface.SharedSource.Controllers
{
    //TODO: Arreglar todos los cshtml del controller
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