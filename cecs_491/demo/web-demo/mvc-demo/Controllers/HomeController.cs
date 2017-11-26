using System.Web.Mvc;

namespace mvc_demo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Page2()
        {
            return Content("Some content");
        }

        public ActionResult Page3()
        {
            return View();
        }
    }
}