using CinemaPlanet.Dal;
using CinemaPlanet.Models;
using CinemaPlanet.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CinemaPlanet.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            MovieDal dal = new MovieDal();
            MovieGallery gallery = new MovieGallery();
            List<Movie> Movies = dal.Movies.ToList<Movie>();
            gallery.Movies = Movies;
            
            return View(gallery);
        }



        public ActionResult EnterMovie()
        {
            MovieDal dal = new MovieDal();
            MovieViewModel mvm = new MovieViewModel();
            List<Movie> Movies = dal.Movies.ToList<Movie>();
            mvm.Movie = new Movie();
            mvm.Movies = Movies;
            return View(mvm);
        }

        public ActionResult SortByMaxPrice()
        {
            MovieDal dal = new MovieDal();
            MovieGallery gallery = new MovieGallery();
            gallery.Movies = dal.Movies.OrderByDescending(m => m.Price).ToList<Movie>();
            
            return View("Index", gallery);
        }

        public ActionResult SortByMinPrice()
        {
            MovieDal dal = new MovieDal();
            MovieGallery gallery = new MovieGallery();
            gallery.Movies = dal.Movies.OrderBy(m => m.Price).ToList<Movie>();

            return View("Index", gallery);
        }

        public ActionResult SortByCategory()
        {
            MovieDal dal = new MovieDal();
            MovieGallery gallery = new MovieGallery();
            gallery.Movies = dal.Movies.OrderBy(m => m.Category).ToList<Movie>();

            return View("Index", gallery);
        }

        public ActionResult EnterDate()
        {
            ViewBag.Flag = 1;
            MovieDal dal = new MovieDal();
            MovieGallery gallery = new MovieGallery();
            gallery.Movies = new List<Movie>();
            string dateValue = Request.Form["txtDate"];

            if (dateValue != null)
            {
                DateTime convertedDate = DateTime.Parse(dateValue);


                List<Movie> temp = (from m in dal.Movies select m).ToList<Movie>();
                foreach (Movie movie in temp)
                {
                    if (movie.mDate.Date == convertedDate.Date)
                    {
                        gallery.Movies.Add(movie);
                    }
                }

                if (gallery.Movies.Count == 0)
                {
                    ViewBag.ErrorMsg = "No Movies found for date entered";
                }

            }
            return View("Index", gallery);
                        
        }

        public ActionResult EnterTime()
        {
            ViewBag.Flag = 2;
            MovieDal dal = new MovieDal();
            MovieGallery gallery = new MovieGallery();
            gallery.Movies = new List<Movie>();
            string TimeValue = Request.Form["txtTime"];

            if (TimeValue != null)
            {
                DateTime convertedDate = DateTime.Parse(TimeValue);
                List<Movie> temp = (from m in dal.Movies select m).ToList<Movie>();

                foreach (Movie movie in temp)
                {
                    if (movie.mDate.TimeOfDay == convertedDate.TimeOfDay)
                    {
                        gallery.Movies.Add(movie);
                    }
                }

                if (gallery.Movies.Count == 0)
                {
                    ViewBag.ErrorMsg = "No Movies found for time entered";
                }
            }

            return View("Index", gallery);


        
        }

        public ActionResult PriceRange()
        {
            ViewBag.Flag = 3;
            MovieDal dal = new MovieDal();
            MovieGallery gallery = new MovieGallery();
            gallery.Movies = new List<Movie>();
            string str = Request.Form["price1"];

            if (str != null)
            {
                int PriceValue1 = int.Parse(Request.Form["price1"]);
                int PriceValue2 = int.Parse(Request.Form["price2"]);

                List<Movie> temp = (from m in dal.Movies select m).ToList<Movie>();

                foreach (Movie movie in temp)
                {
                    if (movie.Price >= PriceValue1 && movie.Price <= PriceValue2)
                    {

                        gallery.Movies.Add(movie);

                    }
                }
            }
            return View("Index", gallery);

        }

        public ActionResult EnterCategory()
        {

            ViewBag.Flag = 4;
            MovieDal dal = new MovieDal();
            MovieGallery gallery = new MovieGallery();
            gallery.Movies = new List<Movie>();
            string CategoryValue = Request.Form["txtCategory"];

            if (CategoryValue != null)
            {

                List <Movie> temp = (from m in dal.Movies select m).ToList<Movie>();

                foreach(Movie movie in temp)
                {
                    if (movie.Category == CategoryValue)
                    {
                        gallery.Movies.Add(movie);
                    }
                }

                if (gallery.Movies.Count == 0)
                {
                    ViewBag.ErrorMsg = "No Movies found for category entered";
                }
            }

            return View("Index", gallery);

        }


        [HttpPost]
        public ActionResult Submit()
        {
            MovieViewModel mvm =  new MovieViewModel();
            Movie MyMovie = new Movie()
            {

                ID = int.Parse(Request.Form["Movie.ID"]).ToString(),
                mName = Request.Form["Movie.mName"],
                mDate = //DateTime.ParseExact(Request.Form["Movie.mDate"], @"MM/dd/yyyy hh:mm:ss", CultureInfo.InvariantCulture),
                DateTime.Parse(Request.Form["Movie.mDate"]),
                Price = int.Parse(Request.Form["Movie.Price"]),
                HallName = Request.Form["Movie.HallName"],
                Age = int.Parse(Request.Form["Movie.Age"]),
                Category = Request.Form["Movie.Category"],

            };

            MovieDal dal = new MovieDal();

            if (ModelState.IsValid)
            {

                dal.Movies.Add(MyMovie);
                dal.SaveChanges();
                mvm.Movie = new Movie();
            }


            else
            {
                mvm.Movie = MyMovie;
            }


            mvm.Movies = dal.Movies.ToList<Movie>();
            return View("EnterMovie", mvm);

        }

        public ActionResult DeleteMovie()
        {
            MovieViewModel mvm = new MovieViewModel();
            mvm.Movie = new Movie();
            MovieDal dal = new MovieDal();
            string nameValue = Request.Form["txtMovieName"];

            if (MovieExist(nameValue))
            {
                Movie delMovie = new Movie { mName = nameValue};
                dal.Movies.Attach(delMovie);
                dal.Movies.Remove(delMovie);
                dal.SaveChanges();
                mvm.Movies = dal.Movies.ToList<Movie>();
                return View(mvm);

            }

            mvm.Movies = dal.Movies.ToList<Movie>();

            return View(mvm);


        }

        public bool MovieExist(string search)
        {
            MovieDal dal = new MovieDal();
            List<Movie> Movies = (from x in dal.Movies where x.mName.Contains(search) select x).ToList<Movie>();

            if (Movies.Count >= 1)
                return true;

            return false;
        }

        public ActionResult ChangePrice()
        {
            MovieViewModel mvm = new MovieViewModel();
            mvm.Movie = new Movie();
            MovieDal dal = new MovieDal();
            string nameValue = Request.Form["txtMovieName"];
            int price = 0;

            if (Request.Form["MoviePrice"] != null)
                price = int.Parse(Request.Form["MoviePrice"]);

            if (MovieExist(nameValue))
            {
                Movie addMovie = dal.Movies.First(a => a.mName == nameValue);
                addMovie.Price = price;
                dal.SaveChanges();
                mvm.Movies = dal.Movies.ToList<Movie>();
                return View(mvm);
            }

            mvm.Movies = dal.Movies.ToList<Movie>();
            return View(mvm);

        }

        

    }


}