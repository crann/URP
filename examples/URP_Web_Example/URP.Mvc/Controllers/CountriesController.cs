using System.Web.Mvc;

namespace URP.Mvc.Controllers
{
    public class CountriesController : Controller
    {
        /// <summary>
        /// GET: /Countries
        /// </summary>
        /// <returns>Countries Details View</returns>
        public ActionResult Details()
        {
            return PartialView();
        }

        /// <summary>
        /// GET: /Countries/Add 
        /// </summary>
        /// <returns>Countries Add View</returns>
        public ActionResult Add()
        {
            return PartialView();
        }

        /// <summary>
        /// GET: /Countries/Edit 
        /// </summary>
        /// <returns>Countries Edit View</returns>
        public ActionResult Edit()
        {
            return PartialView();
        }
    }
}
