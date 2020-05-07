using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using StudyApsCode.Core.Domain;
using StudyApsCode.Core.Repositories;
using StudyApsCode.Persistence.Repositories;

using System;

namespace StudyApsCode.Controllers
{
    public class HomeController : Controller
    {

        private ISearchMovies searchMovies;

        private List<Moives> iMovieList = new List<Moives>();
        public HomeController()
        {
            searchMovies = new SearchMovies();
        }
        protected override void Dispose(bool disposing)
        {
            searchMovies = null;
            iMovieList = null;
        }

        public ActionResult Index()
        {

            return View();
        }


        public async Task<ActionResult> Details()
        {
            try
            {
                var movId = Request.QueryString.Get("MovieID");
                var movieItem = await searchMovies.MoviiesByID(movId);


                return View("Details", movieItem);
            }
            catch (System.Exception)
            {

                throw;
            }

        }

        public async Task<ViewResult> List(SearchCriteria criteria)
        {
            try
            {
                ViewBag.Search = false;
                var movieItem = await searchMovies.Movies(criteria.Title, criteria.Type, criteria.Year);

                iMovieList.Add(movieItem);
                if (movieItem.Response.ToLower() == "true")
                { ViewBag.Search = true; }

                return View("index", iMovieList);
            }
            catch (System.Exception)
            {

                throw;
            }
        }


        public async Task<ActionResult> SelectedItems(Moives items)
        {


            try
            {
                //   List<MoviesItem> movielist = new List<MoviesItem>();

                var rating = 0.0;
                var runtimemovie = 0;
                if (items != null && items.SelectedMovies != null)
                {
                    foreach (var item in items.SelectedMovies)
                    {
                        var movieItem = await searchMovies.MoviiesByID(item);
                        try
                        {
                            if (!movieItem.imdbRating.ToLower().Contains("n/a"))
                            {
                                rating += Convert.ToDouble(movieItem.imdbRating);
                            }
                            if (movieItem.Runtime.ToLower().Contains("min"))
                            {
                                runtimemovie += Convert.ToInt32(movieItem.Runtime.ToLower().Replace("min", ""));
                            }
                        }
                        catch (System.Exception)
                        {
                            ViewBag.Error = "Something Wrong..Please Try Later";
                        }

                        ViewBag.totalTime = runtimemovie;
                        ViewBag.AvgRating = Math.Round(rating / items.SelectedMovies.Count, 2);
                        ViewBag.Search = true;

                    }

                }
                else
                {
                    ViewBag.Error = "Select Aleast One Item From List";
                }
                return View("index", iMovieList);

            }
            catch (System.Exception)
            {
                ViewBag.Error = "Something Wrong..Please Try Later";
                // return HttpNotFound();
                return View("index", iMovieList);
            }
        }




    }
}