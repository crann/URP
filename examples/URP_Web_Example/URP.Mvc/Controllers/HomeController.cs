using System.Web.Mvc;

namespace URP.Mvc.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// GET: /Home/
        /// </summary>
        /// <returns>The website's landing view.</returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}
