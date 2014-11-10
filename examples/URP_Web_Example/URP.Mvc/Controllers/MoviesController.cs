using System;
using System.Collections.Generic;
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
                //----------------------------------------------------
                // Note: Log exceptions.
                //----------------------------------------------------
                return new HttpStatusCodeResult(500);
            }
        }

        /// <summary>
        /// POST: movies/add
        /// </summary>
        public ActionResult Add(Movie movie)
        {
            try
            {
                //----------------------------------------------------
                // Note: Validate the movie data before ading it to 
                //       the repository.
                //----------------------------------------------------
                movieRepository.Add(movie);
                unitOfWork.Commit();

                //----------------------------------------------------
                // Note: If validation errors occur return a 400 and
                //       include any validation errors in the response.
                //----------------------------------------------------
                Response.StatusCode = 201;
                return Json(new { MovieId = movie.MovieId }); 
            }
            catch (Exception ex)
            {
                //----------------------------------------------------
                // Note: Log exceptions.
                //----------------------------------------------------
                return new HttpStatusCodeResult(500);
            }
        }

        /// <summary>
        /// PUT: movies/id
        /// </summary>
        public ActionResult Update(Movie movie)
        {
            try
            {
                movieRepository.Update(movie);
                unitOfWork.Commit();

                return new HttpStatusCodeResult(200);
            }
            catch (Exception ex)
            {
                //----------------------------------------------------
                // Note: Log exceptions.
                //----------------------------------------------------
                return new HttpStatusCodeResult(500);
            }
        }

        /// <summary>
        /// DELETE: movies/id
        /// </summary>
        public ActionResult Delete(int id)
        {
            try
            {   
                movieRepository.Delete(movie => movie.MovieId == id);
                unitOfWork.Commit();

                return new HttpStatusCodeResult(200);
            }
            catch (Exception ex)
            {
                //----------------------------------------------------
                // Note: Log exceptions.
                //----------------------------------------------------
                return new HttpStatusCodeResult(500);
            }
        }
    }
}