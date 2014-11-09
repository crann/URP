using System;
using System.Linq;
using System.Web.Mvc;
using URP.DataAccess.Scaffolding;
using URP.Domain.Entities;

namespace URP.Mvc.Controllers
{
    /// <summary>
    /// Note: This controller is an example of using the repository and unit of work patterns only.
    /// This is not production standard code. 
    /// </summary>
    public class MoviesController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<Movie> movieRepository;

        /// <summary>
        /// Constructor to initialise the controllers resources.
        /// </summary>
        public MoviesController(IUnitOfWork unitOfWork,
                                IRepository<Movie> movieRepository)
        {
            this.unitOfWork = unitOfWork;
            this.movieRepository = movieRepository;
        }

        /// <summary>
        /// GET: /
        /// </summary>
        public ActionResult Index()
        {
            try
            {
                var movies = movieRepository.GetAll().ToList();
                return View(movies);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return View();   
            }
        }

        /// <summary>
        /// POST: movies/add
        /// </summary>
        public JsonResult Add(Movie movie)
        {
            try
            {
                movieRepository.Add(movie);
                unitOfWork.Commit();

                Response.StatusCode = 201;
                return Json(movie);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return new JsonResult();
            }
        }

        /// <summary>
        /// PUT: movies/id
        /// </summary>
        public JsonResult Update(Movie movie)
        {
            try
            {
                movieRepository.Update(movie);
                unitOfWork.Commit();

                Response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
            }

            return new JsonResult();
        }

        /// <summary>
        /// DELETE: movies/id
        /// </summary>
        public JsonResult Delete(int id)
        {
            try
            {   
                movieRepository.Delete(movie => movie.MovieId == id);
                unitOfWork.Commit();

                Response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
            }

            return new JsonResult();
        }
    }
}