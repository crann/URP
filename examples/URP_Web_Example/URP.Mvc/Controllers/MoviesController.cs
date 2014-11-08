using System;
using System.Linq;
using System.Web.Mvc;
using URP.DataAccess.Scaffolding;
using URP.Domain.Entities;

namespace URP.Mvc.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IRepository<Movie> movieRepository;

        /// <summary>
        /// Constructor to initialise the controllers resources.
        /// </summary>
        public MoviesController(IRepository<Movie> movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        /// <summary>
        /// GET: /
        /// </summary>
        /// <returns>Countries Index View</returns>
        public ActionResult Index()
        {
            try
            {
                var movies = movieRepository.GetAll().ToList();
                return View(movies);
            }
            catch (Exception ex)
            {
                return View();   
            }
        }
    }
}
