using System;
using System.Linq;
using System.Web.Mvc;
using URP.DataAccess.Scaffolding;
using URP.Domain.Entities;

namespace URP.Mvc.Controllers
{
    public class CountriesController : Controller
    {
        private readonly IRepository<Country> countryRepository;

        /// <summary>
        /// Constructor to initialise the controllers resources.
        /// </summary>
        public CountriesController(IRepository<Country> countryRepository)
        {
            this.countryRepository = countryRepository;
        }

        /// <summary>
        /// GET: /
        /// </summary>
        /// <returns>Countries Index View</returns>
        public ActionResult Index()
        {
            try
            {
                var countries = countryRepository.GetAll().ToList();
                return View();
            }
            catch (Exception ex)
            {
                return View();   
            }
        }
    }
}
